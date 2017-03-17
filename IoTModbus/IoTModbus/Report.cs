using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace IoTModbus
{
    
    class Report
    {
        // ------------------------------------------------------------------------
        // Private declarations
        DataTable functionTable;
        DataTable exceptionTable;
        private DateTime _startTime;
        private DateTime _stopTime;

        // ------------------------------------------------------------------------
        /// <summary>Constructor for Report class</summary>
        public Report()
        {
            functionTable = getFunctionTable();
            exceptionTable = getExceptionTable();

        }
        static DataTable getFunctionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Function Code", typeof(byte));
            dt.Columns.Add("Function Name", typeof(string));
            dt.Columns.Add("Unit Id", typeof(byte));
            dt.Columns.Add("StartAddress", typeof(ushort));
            dt.Columns.Add("EndAddress",typeof(ushort));
            dt.Columns.Add("Number of Function Calls", typeof(int));

            return dt;
        }
        static DataTable getExceptionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Exception Code", typeof(byte));
            dt.Columns.Add("Exception Name", typeof(string));
            dt.Columns.Add("Exceptions Occurd", typeof(int));            
            return dt;
        }
        // ------------------------------------------------------------------------
        /// <summary>Method for getting and setting a DateTime connectionTime used for logging when the connection was started</summary>
        public DateTime startTime
        {
            get
            {
                return this._startTime;
            }
            set
            {
                    this._startTime = value;
                    System.Diagnostics.Debug.WriteLine("Start Time: " + this.startTime.ToString());
            }
        }

        // ------------------------------------------------------------------------
        /// <summary>Method for getting and setting a DateTime connectionTime used for logging when the connection was started</summary>
        public DateTime stopTime
        {
            get
            {
                return this._stopTime;
            }
            set
            { 
                this._stopTime = value;
                TimeSpan duration = stopTime - startTime;
                System.Diagnostics.Debug.WriteLine("Stop Time: " + this.stopTime.ToString());
                System.Diagnostics.Debug.WriteLine("Duration: " + duration.ToString()); 
            }
        }


    }

}
