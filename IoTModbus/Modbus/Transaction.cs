using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus
{
    class Transaction 
    {
        private ushort _tId;
        private byte _funcNr;
        private byte _unit;
        private ushort _startAddress;
        private ushort _length;
        private DateTime _time;

        public Transaction(ushort tId,byte funcNr,byte unit,ushort startAddress,ushort length)
        {
            _tId = tId;
            _funcNr = funcNr;
            _unit = unit;
            _startAddress = startAddress;
            _length = length;
            _time = DateTime.Now;
        }
        public double tDiff
        {
            get
            {
                DateTime tNow = DateTime.Now;
                double sDiff = (tNow - _time).TotalSeconds;
                return sDiff;
            }
        }
        //Public Properties
        public ushort TId { get { return _tId; } }
        public byte FuncNr { get { return _funcNr; } }
        public byte Unit { get { return _unit; } }
        public ushort StartAddress { get { return _startAddress; } }
        public ushort Length { get { return _length; } }



    }
}
