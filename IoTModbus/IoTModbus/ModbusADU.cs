using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    static class ModbusADU
    {
        
        public static byte[] createADU(byte[] header,byte[] pdu)
        {
            int size = header.Length + pdu.Length;
            byte[] adu = new byte[size];
            Buffer.BlockCopy(header, 0, adu, 0, header.Length);
            Buffer.BlockCopy(pdu, 0, adu, header.Length, pdu.Length);
            return adu;
        }
    }
}
