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
        private DateTime openTime;
        private DateTime closeTime;
        private DateTime runningTime;
        private DateTime startTime;
        private DateTime stopTime;
        private DateTime connectedTime;
        

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

            dt.Rows.Add(1, "Read Coil", 1, null, null, 0);
            dt.Rows.Add(2, "Read Discrete Input", 1, null, null, 0);
            dt.Rows.Add(3, "Read Holding Register", 1, null, null, 0);
            dt.Rows.Add(4, "Read Input Register", 1, null, null, 0);
            dt.Rows.Add(5, "Write Singel Coil", 1, null, null, 0);
            dt.Rows.Add(6, "Write Singel Register", 1, null, null, 0);
            dt.Rows.Add(15, "Write Multiple Coils", 1, null, null, 0);
            dt.Rows.Add(16, "Write Multiple Registers", 1, null, null, 0);
            return dt;
        }
        static DataTable getExceptionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Exception Code", typeof(byte));
            dt.Columns.Add("Exception Name", typeof(string));
            dt.Columns.Add("Transaction Id", typeof(ushort));
            dt.Columns.Add("Unit Id", typeof(byte));
            dt.Columns.Add("Function Code", typeof(byte));
            dt.Columns.Add("Timestamp", typeof(DateTime));
            return dt;
        }

        public void recordFunctionTransaction(byte funcNr, byte unit, ushort startAddress, ushort length)
        {
            DataRow[] funcRow = functionTable.Select("[Function Code] =" + funcNr);

            if (funcRow[0]["StartAddress"].ToString().Length == 0)
            {
                funcRow[0]["StartAddress"] = startAddress;
            }
            else if ((ushort)funcRow[0]["StartAddress"] > startAddress) funcRow[0]["StartAddress"] = startAddress;
            
            if (funcRow[0]["EndAddress"].ToString().Length == 0)
            {
                funcRow[0]["EndAddress"] = startAddress + length;
            }
            else if ((ushort)funcRow[0]["EndAddress"] < startAddress + length ) funcRow[0]["StartAddress"] = startAddress + length ;

            int tempCount = (int)funcRow[0]["Number of Function Calls"];

            funcRow[0]["Number of Function Calls"] = tempCount + 1;

        }

        public void recordException(ushort tId,byte funcNr,byte unit,byte exep,string excepMessage)
        {
            exceptionTable.Rows.Add(exep, excepMessage, tId, unit, funcNr, DateTime.Now);
        }

        // ------------------------------------------------------------------------
        /// <summary>Method for getting and setting a DateTime connectionTime used for logging when the connection was started</summary>
        public DateTime StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                if (!ComHandler.Connected)
                {
                    this.startTime = value;
                    System.Diagnostics.Debug.WriteLine("Start Time: " + this.startTime.ToString());
                }
            }
        }

        // ------------------------------------------------------------------------
        /// <summary>Method for getting and setting a DateTime connectionTime used for logging when the connection was started</summary>
        public DateTime StopTime
        {
            get
            {
                return this.stopTime;
            }
            set
            {
                if (ComHandler.Connected)
                {
                    this.stopTime = value;
                    TimeSpan duration = this.stopTime - this.startTime;
                    this.connectedTime += duration;
                    System.Diagnostics.Debug.WriteLine("Stop Time: " + this.stopTime.ToString());
                    System.Diagnostics.Debug.WriteLine("Duration: " + duration.ToString());
                }
            }
        }
        public DateTime OpenTime
        {
            get{ return this.openTime ; }
            set{ this.openTime = value; }
        }
        public DateTime CloseTime
        {
            get { return this.closeTime;  }
            set
            {
                this.closeTime = value;
                TimeSpan duration = this.closeTime - this.openTime;
                this.runningTime += duration;
            }
        }

        public void generateReport()
        {
            DateTime[] times = { OpenTime, CloseTime, runningTime,connectedTime };
            PDF.createPDF(functionTable,exceptionTable,times);
        }

    }

}
