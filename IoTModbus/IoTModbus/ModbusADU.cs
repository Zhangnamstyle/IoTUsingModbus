using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    /// <summary>
    /// Static Class for creating and decode Modbus Application Data Unit(ADU)
    /// </summary>
    static class ModbusADU
    {
        // ------------------------------------------------------------------------
        /// <summary>Creates the ADU(Application Data Unit) to send for Modbus TCP/IP</summary>
        /// <param name="header">Modbus Function Code.</param>
        /// <param name="pdu">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        public static byte[] createADU(byte[] header,byte[] pdu)
        {
            int size = header.Length + pdu.Length;
            byte[] adu = new byte[size];
            Buffer.BlockCopy(header, 0, adu, 0, header.Length);
            Buffer.BlockCopy(pdu, 0, adu, header.Length, pdu.Length);
            return adu;
        }


        // ------------------------------------------------------------------------
        /// <summary>Decodes the ADU(Application Data Unit) recived using Modbus TCP/IP </summary>
        /// <param name="adu">Modbus ADU(Application Data Unit)</param>
        /// <param name="_pdu">Modbus PDU(Protocol Data Unit)</param>
        public static byte[] decodeADU(byte[] adu, out byte[] _pdu)
        {
                byte[] header = new byte[7];
                byte[] pdu = new byte[adu.Length - 7];

                Buffer.BlockCopy(adu, 0, header, 0, header.Length);
                Buffer.BlockCopy(adu, header.Length, pdu, 0, pdu.Length);

                _pdu = pdu;

                return header;
        }

        //// MADE READY FOR MODBUS RTU
        //// ------------------------------------------------------------------------
        ///// <summary>Decodes the ADU(Application Data Unit) recived using Modbus RTU </summary>
        ///// <param name="adu">Modbus ADU(Application Data Unit)</param>
        ///// <param name="_pdu">Modbus PDU(Protocol Data Unit)</param>
        //public static byte[] decodeADU(byte[] adu, out byte[] _pdu,out byte[] _crc)
        //{

        //        byte[] header = new byte[1];
        //        byte[] pdu = new byte[adu.Length - 3];
        //        byte[] crc = new byte[2];

        //        Buffer.BlockCopy(adu, 0, header, 0, header.Length);
        //        Buffer.BlockCopy(adu, header.Length, pdu, 0, pdu.Length);
        //        Buffer.BlockCopy(adu, header.Length + pdu.Length, crc, 0, crc.Length);

        //        _pdu = pdu;
        //        _crc = crc;

        //        return header;
        //}
        //// ------------------------------------------------------------------------
        ///// <summary>Creates the ADU(Application Data Unit) to send for Modbus RTU</summary>
        ///// <param name="header">Modbus Function Code.</param>
        ///// <param name="pdu">Unique id that marks the transaction. In asynchonous mode this id is given to the callback function.</param>
        //public static byte[] createADU(byte[] header, byte[] pdu, byte[] crc)
        //{
        //    int size = header.Length + pdu.Length + crc.Length;
        //    byte[] adu = new byte[size];
        //    Buffer.BlockCopy(header, 0, adu, 0, header.Length);
        //    Buffer.BlockCopy(pdu, 0, adu, header.Length, pdu.Length);
        //    Buffer.BlockCopy(crc, 0, adu, header.Length + pdu.Length, crc.Length);
        //    return adu;
        //}
    }
}

