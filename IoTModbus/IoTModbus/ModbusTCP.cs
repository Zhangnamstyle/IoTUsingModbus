using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

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
        private static bool _connected = false;
        private byte[] tcpBuffer = new byte[15];

        private ushort _id;

        List<Transaction> transactions = new List<Transaction>();

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
        public ModbusTCP(string ip, ushort port, Report rep)
        {
            _report = rep;
            connectTCP(ip, port);
        }
        // ------------------------------------------------------------------------
        /// <summary>Send modbus message for reading over TCP</summary>
        /// <param name="funcNr">Modbus Function Code.</param>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="unit">Unit identifier (previously slave address). In asynchonous mode this unit is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numInputs">Length of data.</param>
        public void sendTCP(byte funcNr,ushort id, byte unit, ushort startAddress, ushort numInputs)
        {
            byte[] head;
            byte[] pdu;
            byte[] adu;
            head = createMBAP(id, unit);
            pdu = ModbusPDU.CreatePDU(funcNr, startAddress, numInputs);
            adu = ModbusADU.createADU(head, pdu);
            WriteData(adu, id);
            
        }

        // ------------------------------------------------------------------------
        /// <summary>Send modbus message for writing over TCP</summary>
        /// <param name="funcNr">Modbus Function Code.</param>
        /// <param name="id">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        /// <param name="unit">Unit identifier (previously slave address). In asynchonous mode this unit is given to the callback function.</param>
        /// <param name="startAddress">Address from where the data read begins.</param>
        /// <param name="numBits">Specifys number of bits.</param>
        /// <param name="values">Contains the bit information in byte format.</param>
        public void sendTCP(byte funcNr,ushort id, byte unit, ushort startAddress,ushort numBits, byte[] values)
        {
            byte numBytes;
            numBytes = Convert.ToByte(values.Length); //TODO: Debug and find right way to set numBytes
            byte[] head;
            byte[] pdu;
            byte[] adu;
            head = createMBAP(id, unit, numBytes);
            pdu = ModbusPDU.CreatePDU(funcNr, startAddress, (byte)(numBytes + 2),numBits,values);
            adu = ModbusADU.createADU(head, pdu);
            WriteData(adu, id);
        }

        // ------------------------------------------------------------------------
        /// <summary>Connects to the Modbus slave</summary>
        /// <param name="ip">IP adress of modbus slave.</param>
        /// <param name="port">Port number of modbus slave. Usually port 502 is used.</param>
        private void connectTCP(string ip, ushort port)
        {
            try
            {
                IPAddress _ip;
                if (IPAddress.TryParse(ip, out _ip) == false)
                {
                    IPHostEntry hst = Dns.GetHostEntry(ip);
                    ip = hst.AddressList[0].ToString();
                }

                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(ip), port);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay,true);
                
                netStream = tcpClient.GetStream();
                _connected = true;
                _report.startTime = DateTime.Now;
            }
            catch (Exception error)
            {
                _connected = false;
                throw (error);
            }
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
                _report.stopTime = DateTime.Now;
            }
        }

        // ------------------------------------------------------------------------
        /// <summary>Returns a Modbus Application Header for writing registers as a byte array</summary>
        private byte[] createMBAP(ushort id, byte unit, ushort numBytes)
        {
            byte[] mbap = new byte[7]; //TODO: Check size of header

            byte[] _id = BitConverter.GetBytes((short)id);
            mbap[0] = _id[1];           //Slave id high byte
            mbap[1] = _id[0];           //Slave id low byte
            byte[] _size = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)(5 + numBytes))); //TODO: Needs to find size of numBytes
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
        private void WriteData(byte[] adu, ushort id)
        {
            if ((tcpClient != null) && (tcpClient.Connected))
            {
                try
                {
                    if (netStream.CanWrite)
                    {
                        bool notUnique = transactions.Any(p => p.tId == id);
                        if (notUnique) { }    //TODO: Create Error handling 
                        else
                        {

                            string s = ByteArrayToString(adu);
                            System.Diagnostics.Debug.WriteLine(s); //Remove when release
                            _id = id;
                            netStream.BeginWrite(adu, 0, adu.Length, new AsyncCallback(recieveCallBack), id);
                            netStream.BeginRead(tcpBuffer, 0, tcpBuffer.Length, new AsyncCallback(OnReceive), id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
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
            ushort tId = (ushort)ar.AsyncState;
            netStream.EndWrite(ar);
            transactions.Add(new Transaction(tId));
        }

        // ------------------------------------------------------------------------
        /// <summary>Handles the response from modbus slave</summary>
        private void OnReceive(System.IAsyncResult ar)
        {
            if (ar.IsCompleted == false) { } //TODO: Add Exeption

            ushort tId = (ushort)ar.AsyncState;
            var itemToRemove = transactions.SingleOrDefault(p => p.tId == tId);
            if (itemToRemove != null) transactions.Remove(itemToRemove);
            checkForTimeout();


            byte[] pdu;
            byte funcNr;
            bool ex;
            byte[] mbap = ModbusADU.decodeADU(tcpBuffer,out pdu);
            byte[] data = ModbusPDU.ReadPDU(pdu,out funcNr,out ex);

            ushort id = SwapUInt16(BitConverter.ToUInt16(mbap, 0));
            byte unit = mbap[6];
            if(!ex)
            {
                if (OnResponseDataTCP != null) OnResponseDataTCP(id, unit, funcNr, data);
                System.Diagnostics.Debug.WriteLine("Response data = " + " FuncNumber = " + funcNr.ToString() + " Value " + ByteArrayToString(data));
            }
            else if(ex)
            {
                if (OnExceptionTCP != null) OnExceptionTCP(id, unit, funcNr,data[0]);
                System.Diagnostics.Debug.WriteLine("ExceptionData = " + " FuncNumber = " + funcNr.ToString() + " Value " + ByteArrayToString(data));
            }

        }

        private void checkForTimeout()
        {
            //foreach(Transaction transaction in transactions)
            //{
            //    bool tOut = transaction.Timeout();
            //    if (tOut)
            //    {
            //        //TODO: Add code for reporting timeout object
            //        transactions.Remove(transaction);
            //    }
            //}
            var itemToRemove = transactions.SingleOrDefault(p => p.tDiff >= 5);
            if (itemToRemove != null)
            {
                //TODO: Report Id and timeouttime
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
