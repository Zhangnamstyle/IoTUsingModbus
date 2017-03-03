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
        Report _report;
        public ModbusTCP(string ip,ushort port, Report report)
        {
            _report = report;
            connect(ip, port);
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
                tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(ip), port);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, _timeout);
                tcpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, _timeout);
                netStream = tcpClient.GetStream();
                _connected = true;
                _report.startTime = DateTime.Now;
            }
            catch(Exception error)
            {
                _connected = false;
                throw (error);
            }
        }
        public void disconnect()
        {
            if(tcpClient != null)
            {
                if(tcpClient.Connected)
                {
                    netStream.Close();
                    tcpClient.Close();       
                }
                netStream = null;
                tcpClient = null;
                _report.stopTime = DateTime.Now;
            }
        }
        /// <summary>Returns a Modbus Application Header for writing as a byte array</summary>
        private byte[] createWriteMBAP(ushort id, byte unit, ushort startAdress, ushort numData, ushort numBytes,byte funcNr)
        {
            byte[] mbap = new byte[2]; //TODO: Find size of header

            byte[] _id = BitConverter.GetBytes((short)id);
            mbap[0] = _id[1];           //Slave id high byte
            mbap[1] = _id[0];           //Slave id low byte
            byte[] _size = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)(5 + 5))); //TODO: Needs to find size of numBytes
            mbap[4] = _size[0];			// Complete message size in bytes
            mbap[5] = _size[1];         // Complete message size in bytes
            mbap[6] = unit;             // Slave Adress
            mbap[7] = funcNr;           // Function Code
            byte[] _adr = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)startAdress));
            mbap[8] = _adr[0];          //
            mbap[9] = _adr[1];
            if (funcNr == 15) {          //Make declare
                byte[] _cnt = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)numData));
                mbap[10] = _cnt[0];
                mbap[11] = _cnt[1];
                mbap[12] = (byte)(numBytes - 2);
            }
                return mbap;
        }
        /// <summary>Returns a Modbus Application Header for reading as a byte array</summary>
        private byte[] createReadMBAP(ushort id,byte unit, ushort startAddress,ushort length,byte funcNr)
        {
            byte[] mbap = new byte[12];

            byte[] _id = BitConverter.GetBytes((short)id);
            mbap[0] = _id[1];			    // Slave id high byte
            mbap[1] = _id[0];				// Slave id low byte
            mbap[5] = 6;					// Message size
            mbap[6] = unit;					// Slave address
            mbap[7] = funcNr;				// Function code
            byte[] _adr = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)startAddress));
            mbap[8] = _adr[0];				// Start address
            mbap[9] = _adr[1];				// Start address
            byte[] _length = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)length));
            mbap[10] = _length[0];			// Number of data to read
            mbap[11] = _length[1];			// Number of data to read

            return mbap;
        }
    }

    
}
