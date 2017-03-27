using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IoTModbus
{
    /// <summary>
    /// Facade class for Modbus Communication using TCP/IP portocol.
    /// </summary>
    class ModbusTCP 
    {
        // ------------------------------------------------------------------------
        // Private declarations
        private TcpClient tcpClient;
        private NetworkStream netStream;
        private Report _report;
            
        private static ushort _timeout = 500;
        private byte[] tcpBuffer = new byte[200];

        private string ip;
        private ushort port;

        List<Transaction> transactions = new List<Transaction>();
        static SemaphoreSlim _sem = new SemaphoreSlim(1);

        // ------------------------------------------------------------------------
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void ResponseDataTCP(ushort id, byte unit, byte function, byte[] data);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ResponseDataTCP OnResponseDataTCP;
        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public delegate void ExceptionDataTCP(ushort id, byte unit, byte function, byte exception);
        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public event ExceptionDataTCP OnExceptionTCP;

        // ------------------------------------------------------------------------
        /// <summary>Write multiple registers in slave asynchronous. The result is given in the response function.</summary>
        /// <param name="ip">IP adress of modbus slave.</param>
        /// <param name="port">Port number of modbus slave. Usually port 502 is used.</param>
        /// <param name="report">Object of class Report.</param>
        public ModbusTCP(string _ip, ushort _port, Report rep)
        {
            _report = rep;
            ip = _ip;
            port = _port;
            connectTCP();
        }
        // ------------------------------------------------------------------------
        /// <summary>Send modbus message for reading over TCP</summary>
        /// <param name="funcNr">Modbus Function Code.</param>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="unit">Unit identifier (previously slave address). In asynchonous mode this unit is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        public void sendTCP(byte funcNr,ushort tId, byte unit, ushort startAddress, ushort numInputs)
        {
            byte[] head;
            byte[] pdu;
            byte[] adu;
            head = createMBAP(tId, unit);
            pdu = ModbusPDU.CreatePDU(funcNr, startAddress, numInputs);
            adu = ModbusADU.createADU(head, pdu);
            Transaction txn = new Transaction(tId, funcNr, unit, startAddress, numInputs);
            WriteData(adu, txn);
            
        }

        // ------------------------------------------------------------------------
        /// <summary>Send modbus message for writing over TCP</summary>
        /// <param name="funcNr">Modbus Function Code.</param>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="unit">Unit identifier (previously slave address). In asynchonous mode this unit is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numBits">Specifys number of bits.</param>
        /// <param name="values">Contains the bit information in byte format.</param>
        public void sendTCP(byte funcNr,ushort tId, byte unit, ushort startAddress,ushort numBits, byte[] values)
        {
            byte numBytes;
            numBytes = Convert.ToByte(values.Length);
            byte[] head;
            byte[] pdu;
            byte[] adu;
            ushort nBytes;
            ushort nRegs;
            pdu = ModbusPDU.CreatePDU(funcNr, startAddress, numBytes, numBits, values, out nBytes,out nRegs);
            head = createMBAP(tId, unit, nBytes);
            adu = ModbusADU.createADU(head, pdu);
            Transaction t = new Transaction(tId, funcNr, unit, startAddress, nRegs);
            WriteData(adu, t);
        }

        public void reportSlaveID(ushort tId,byte unit)
        {
            byte funcNr = 17;
            byte[] head = createMBAP(tId, unit,1);
            byte[] pdu = new byte[1];
            pdu[0] = funcNr;
            byte[] adu = ModbusADU.createADU(head, pdu);
            Transaction txn = new Transaction(tId, funcNr, unit, 0, 0);
            WriteData(adu, txn);
        }

        // ------------------------------------------------------------------------
        /// <summary>Connects to the Modbus slave</summary>
        /// <param name="ip">IP adress of modbus slave.</param>
        /// <param name="port">Port number of modbus slave. Usually port 502 is used.</param>
        private void connectTCP()
        {
                //TODO: CHECK IP IN GUI
                //if (IPAddress.TryParse(ip, out _ip) == false)
                //{
                //    IPHostEntry hst = Dns.GetHostEntry(ip);
                //    ip = hst.AddressList[0].ToString();
                //}

                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(ip), port);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);

                netStream = tcpClient.GetStream();

                _report.StartTime = DateTime.Now;
        }

        // ------------------------------------------------------------------------
        /// <summary>Write multiple coils in slave asynchronous. The result is given in the response function.</summary>
        public void disconnect()
        {
            if (tcpClient != null)
            {
                if (tcpClient.Connected)
                {
                    netStream.Close();
                    tcpClient.Close();
                }
                netStream = null;
                tcpClient = null;
                _report.StopTime = DateTime.Now;
            }
        }

        // ------------------------------------------------------------------------
        /// <summary>Returns a Modbus Application Header for writing registers as a byte array</summary>
        private byte[] createMBAP(ushort id, byte unit, ushort numBytes)
        {
            byte[] mbap = new byte[7];

            byte[] _id = BitConverter.GetBytes((short)id);
            mbap[0] = _id[1];           //Transaction id high byte
            mbap[1] = _id[0];           //Transaction id low byte
            byte[] _size = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)(5 + numBytes)));
            mbap[4] = _size[0];			// Complete message size in bytes
            mbap[5] = _size[1];         // Complete message size in bytes
            mbap[6] = unit;             // Slave Adress

            return mbap;
        }

        // ------------------------------------------------------------------------
        /// <summary>Returns a Modbus Application Header for reading registers as a byte array</summary>
        private byte[] createMBAP(ushort id, byte unit)
        {
            byte[] mbap = new byte[7];

            byte[] _id = BitConverter.GetBytes((short)id);
            mbap[0] = _id[1];			    // Slave id high byte
            mbap[1] = _id[0];				// Slave id low byte
            mbap[5] = 6;					// Message size
            mbap[6] = unit;					// Slave address
            return mbap;
        }

        // ------------------------------------------------------------------------
        /// <summary>Writes the adu to the Modbus Slave</summary>
        private void WriteData(byte[] adu, Transaction txn)
        {
            if ((tcpClient != null) && (tcpClient.Connected))
            {
                
                    if (netStream.CanWrite)
                    {
                    _sem.Wait();
                        bool notUnique = transactions.Any(l => l.TId == txn.TId);
                    _sem.Release();
                        if (notUnique) { }    //TODO: Create Error handling 
                        else
                        {

                            string s = ByteArrayToString(adu);
                            System.Diagnostics.Debug.WriteLine(s); //Remove when release      
                            netStream.BeginWrite(adu, 0, adu.Length, new AsyncCallback(recieveCallBack), txn);
                            netStream.BeginRead(tcpBuffer, 0, tcpBuffer.Length, new AsyncCallback(OnReceive), txn);
                        }
                    }
                
            }
        }

        // ------------------------------------------------------------------------
        /// <summary>Writes the adu to the Modbus Slave</summary>
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        // ------------------------------------------------------------------------
        /// <summary>Writes the adu to the Modbus Slave</summary>
        private void recieveCallBack(IAsyncResult ar)
        {
            if (ar.IsCompleted == false) { } //TODO: Add Exeption
            Transaction t = (Transaction)ar.AsyncState;
            _sem.Wait();
            transactions.Add(t);
            _sem.Release();
            _report.recordFunctionTransaction(t.FuncNr, t.Unit, t.StartAddress, t.Length);
            netStream.EndWrite(ar);
            System.Diagnostics.Debug.WriteLine("out" + t.TId.ToString());
        }

        // ------------------------------------------------------------------------
        /// <summary>Handles the response from modbus slave</summary>
        private void OnReceive(System.IAsyncResult ar)
        {
            try
            {
                if (ar.IsCompleted == false) { } //TODO: Add Exeption

                Transaction t = (Transaction)ar.AsyncState;
                _sem.Wait();
                var itemToRemove = transactions.SingleOrDefault(p => p.TId == t.TId);
                if (itemToRemove != null) transactions.Remove(itemToRemove);
                checkForTimeout();
                _sem.Release();


                byte[] pdu;
                byte funcNr;
                bool ex;
                byte[] mbap = ModbusADU.decodeADU(tcpBuffer, out pdu);
                byte[] data = ModbusPDU.ReadPDU(pdu, out funcNr, out ex);

                ushort id = SwapUInt16(BitConverter.ToUInt16(mbap, 0));
                byte unit = mbap[6];
                if (!ex)
                {
                    if (OnResponseDataTCP != null) OnResponseDataTCP(id, unit, funcNr, data); //TODO: TRIM TCP REGISTER
                    System.Diagnostics.Debug.WriteLine("in" + id.ToString());
                }
                else if (ex)
                {

                    if (OnExceptionTCP != null) OnExceptionTCP(id, unit, funcNr, data[0]);
                    System.Diagnostics.Debug.WriteLine("ExceptionData = " + " FuncNumber = " + funcNr.ToString() + " Value " + ByteArrayToString(data));
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }

        }

        private void checkForTimeout()
        {

            var itemToRemove = transactions.SingleOrDefault(p => p.tDiff >= 5);
            if (itemToRemove != null)
            {
                //TODO: Report Id and timeouttime and FIX issue
                transactions.Remove(itemToRemove);
            }

        }

        internal static UInt16 SwapUInt16(UInt16 inValue)
        {
            return (UInt16)(((inValue & 0xff00) >> 8) |
                     ((inValue & 0x00ff) << 8));
        }

        

    }
    }
