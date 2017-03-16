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
        private DateTime time;

        public Transaction(ushort id)
        {
            _tId = id;
            time = DateTime.Now;
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
        
        public ushort tId
        {
            get { return _tId; }
        }
        

        
    }
}
