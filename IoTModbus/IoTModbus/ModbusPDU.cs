using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    static class ModbusPDU
    {
        /// <summary>Returns a PDU for Writing </summary>
        public static byte[] CreatePDU(byte funcNr,ushort startAddress,ushort numBytes,ushort numData,byte[] values)
        {

            byte[] pdu = new byte[numBytes + 4];
            pdu[0] = funcNr;
            byte[] _adr = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)startAddress));
            pdu[1] = _adr[0];
            pdu[2] = _adr[1];
            if(funcNr >= 15) //Larger or equal to function number for multiple coils
            {
                byte[] _cnt = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)numData));
                pdu[3] = _cnt[0];			// Number of bytes
                pdu[4] = _cnt[1];			// Number of bytes
                pdu[5] = (byte)(numBytes - 2);
                Array.Copy(values, 0, pdu, 6, numBytes);
            }
            else
            {
                pdu[3] = values[0];
                pdu[4] = values[1];
            }
            return pdu;
        }

        /// <summary>Returns a PDU for Reading </summary>
        public static byte[] CreatePDU(byte funcNr, ushort startAddress,ushort length)
        {

            byte[] pdu = new byte[5];
            pdu[0] = funcNr;
            byte[] _adr = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)startAddress));
            pdu[1] = _adr[0];
            pdu[2] = _adr[1];
            byte[] _length = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)length));
            pdu[3] = _length[0];			// Number of data to read
            pdu[4] = _length[1];			// Number of data to read
            return pdu;
        }


    }
}
