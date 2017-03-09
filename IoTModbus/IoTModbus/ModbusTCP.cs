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
    /// '
    class ModbusTCP
    {
        private TcpClient tcpClient;
        private NetworkStream netStream;
        private static ushort _timeout = 500;
        private static bool _connected = false;
        private byte[] tcpBuffer = new byte[15];
        Report _report;

        public ModbusTCP(string ip, ushort port, Report report)
        {
            
            _report = report; 
            connect(ip, port);
        }

        /// <summary>Send modbus message for reading over TCP</summary>
        public void send(byte funcNr,ushort id, byte unit, ushort startAddress, ushort numInputs)
        {
            byte[] head;
            byte[] pdu;
            byte[] adu;
            head = createMBAP(id, unit);
            pdu = ModbusPDU.CreatePDU(funcNr, startAddress, numInputs);
            adu = ModbusADU.createADU(head, pdu);
            WriteData(adu, id);
        }
        /// <summary>Send modbus message for writing over TCP</summary>
        public void send(byte funcNr,ushort id, byte unit, ushort startAddress,ushort numBits, byte[] values)
        {
            byte numBytes;
            if (values.Length < 4)
            {
                numBytes = Convert.ToByte(values.Length);
            }
            else { numBytes = 1; }
            byte[] head;
            byte[] pdu;
            byte[] adu;
            head = createMBAP(id, unit, numBytes);
            pdu = ModbusPDU.CreatePDU(funcNr, startAddress, numBytes,1,values);
            adu = ModbusADU.createADU(head, pdu);
            WriteData(adu, id);
        }


        /// <summary>Connects to the Modbus slave</summary>
        /// <param name="ip">IP adress of modbus slave.</param>
        /// <param name="port">Port number of modbus slave. Usually port 502 is used.</param>
        private void connect(string ip, ushort port)
        {
            try
            {
                IPAddress _ip;
                if (IPAddress.TryParse(ip, out _ip) == false)
                {
                    IPHostEntry hst = Dns.GetHostEntry(ip);
                    ip = hst.AddressList[0].ToString();
                }

                int size = sizeof(UInt32);
                UInt32 on = 1;
                UInt32 keepAliveInterval = 750; //Send a packet once every second.
                UInt32 retryInterval = 200; //If no response, resend every second.
                byte[] inArray = new byte[size * 3];
                Array.Copy(BitConverter.GetBytes(on), 0, inArray, 0, size);
                Array.Copy(BitConverter.GetBytes(keepAliveInterval), 0, inArray, size, size);
                Array.Copy(BitConverter.GetBytes(retryInterval), 0, inArray, size * 2, size);


                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(ip), port);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay,true);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive,true);
                tcpClient.Client.IOControl(IOControlCode.KeepAliveValues,inArray,null);
                
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
        /// <summary>Returns a Modbus Application Header for writing registers as a byte array</summary>
        private byte[] createMBAP(ushort id, byte unit, ushort numBytes)
        {
            byte[] mbap = new byte[7]; //TODO: Check size of header

            byte[] _id = BitConverter.GetBytes((short)id);
            mbap[0] = _id[1];           //Slave id high byte
            mbap[1] = _id[0];           //Slave id low byte
            byte[] _size = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)(5 + 5))); //TODO: Needs to find size of numBytes
            mbap[4] = _size[0];			// Complete message size in bytes
            mbap[5] = _size[1];         // Complete message size in bytes
            mbap[6] = unit;             // Slave Adress

            return mbap;
        }
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

        /// <summary>Writes the adu to the Modbus Slave</summary>
        private void WriteData(byte[] adu, ushort id)
        {
            if ((tcpClient != null) && (tcpClient.Connected))
            {
                try
                {
                    if (netStream.CanWrite)
                    {
                        string s = ByteArrayToString(adu);
                        System.Diagnostics.Debug.WriteLine(s);
                        netStream.BeginWrite(adu, 0, adu.Length, new AsyncCallback(recieveCallBack), netStream);
                        netStream.BeginRead(tcpBuffer, 0, tcpBuffer.Length, new AsyncCallback(OnReceive), netStream);
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
        }
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void recieveCallBack(IAsyncResult ar)
        {
            netStream.EndWrite(ar);
        }
        private void OnReceive(System.IAsyncResult result)
        {
            
        }

    }
    }
