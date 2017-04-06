using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;

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
        private SemaphoreSlim _sem;
        

        // ------------------------------------------------------------------------
        /// <summary>Constructor for Report class.</summary>
        public Report()
        {
            functionTable = getFunctionTable();
            exceptionTable = getExceptionTable();
            _sem = new SemaphoreSlim(1);
        }

        // ------------------------------------------------------------------------
        /// <summary>Returns a DataTable filled with the supported Modbus Function Codes.</summary>
        static DataTable getFunctionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Function Code", typeof(byte));
            dt.Columns.Add("Function Name", typeof(string));
            dt.Columns.Add("Start Address", typeof(ushort));
            dt.Columns.Add("End Address",typeof(ushort));
            dt.Columns.Add("Number of Function Calls", typeof(int));

            dt.Rows.Add(1, "Read Coil", null, null, 0);
            dt.Rows.Add(2, "Read Discrete Input", null, null, 0);
            dt.Rows.Add(3, "Read Holding Register", null, null, 0);
            dt.Rows.Add(4, "Read Input Register", null, null, 0);
            dt.Rows.Add(5, "Write Singel Coil", null, null, 0);
            dt.Rows.Add(6, "Write Singel Register", null, null, 0);
            dt.Rows.Add(15, "Write Multiple Coils", null, null, 0);
            dt.Rows.Add(16, "Write Multiple Registers", null, null, 0);
            return dt;
        }

        // ------------------------------------------------------------------------
        /// <summary>Returns a DataTable filled with the supported Modbus Exception Codes.</summary>
        static DataTable getExceptionTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Exception Code", typeof(byte));
            dt.Columns.Add("Exception Name", typeof(string));
            dt.Columns.Add("Transaction Id", typeof(ushort));
            dt.Columns.Add("Function Code", typeof(byte));
            dt.Columns.Add("Timestamp", typeof(DateTime));
            return dt;
        }

        // ------------------------------------------------------------------------
        /// <summary>Records the function transaction in the report.</summary>
        /// <param name="funcNr">Function Code</param>
        public void recordFunctionTransaction(byte funcNr, ushort startAddress, ushort length)
        {
            _sem.Wait(); //SEMPAHORE

            if (funcNr != 17)
            {
                DataRow[] funcRow = functionTable.Select("[Function Code] =" + funcNr);

                if (funcRow[0]["Start Address"].ToString().Length == 0 || funcRow[0]["Start Address"] == null)
                {
                    funcRow[0]["Start Address"] = startAddress;
                }
                else if ((ushort)funcRow[0]["Start Address"] > startAddress) funcRow[0]["Start Address"] = startAddress;

                if (funcRow[0]["End Address"].ToString().Length == 0 || funcRow[0]["End Address"] == null)
                {
                    funcRow[0]["End Address"] = startAddress + length;
                }
                else if ((ushort)funcRow[0]["End Address"] < startAddress + length) funcRow[0]["Start Address"] = startAddress + length;

                int tempCount = (int)funcRow[0]["Number of Function Calls"];

                funcRow[0]["Number of Function Calls"] = tempCount + 1;
            }
            _sem.Release(); //SEMPAHORE

        }

        public void recordException(ushort tId,byte funcNr,byte exep,string excepMessage)
        {
            exceptionTable.Rows.Add(exep, excepMessage, tId, funcNr, DateTime.Now);
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

                    this.startTime = value;
                    System.Diagnostics.Debug.WriteLine("Start Time: " + this.startTime.ToString());
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
                    this.stopTime = value;
                    TimeSpan duration = this.stopTime - this.startTime;
                    this.connectedTime += duration;
                    System.Diagnostics.Debug.WriteLine("Stop Time: " + this.stopTime.ToString());
                    System.Diagnostics.Debug.WriteLine("Duration: " + duration.ToString());
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
