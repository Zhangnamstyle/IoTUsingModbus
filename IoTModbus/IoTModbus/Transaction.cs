using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    class Transaction 
    {
        private ushort _tId;
        private byte _unit;
        private byte _funcNr;
        private ushort _startAddress;
        private ushort _numReg; 
        private DateTime time;

        public Transaction(ushort id,byte unit,byte funcNr,ushort startAddress,ushort numReg)
        {
            _tId = id;
            _unit = unit;
            _funcNr = funcNr;
            _startAddress = startAddress;
            _numReg = numReg;
            time = DateTime.Now;
        }

        public ushort TId
        {
            get { return _tId; }
        }

        public byte Unit
        {
            get { return _unit; }
        }

        public byte FuncNr
        {
            get { return _funcNr; }
        }

        public ushort StartAddress
        {
            get { return _startAddress; }
        }

        public ushort NumReg
        {
            get { return _numReg; }
        }

        public double tDiff
        {
            get
            {
                DateTime tNow = DateTime.Now;
                double sDiff = (tNow - time).TotalSeconds;
                return sDiff;
            }
        }


    }
}
