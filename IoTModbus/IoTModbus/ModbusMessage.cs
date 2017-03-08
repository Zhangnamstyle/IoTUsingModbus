using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    static class ModbusMessage
    {
        public static byte[] createPDU(ushort startAddress, ushort numData, ushort numBytes, byte funcNr)
        {
            
            byte[] data = new byte[numBytes];

           

            return data;
        }
    }
}
