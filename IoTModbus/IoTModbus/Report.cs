using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    
    class Report
    {
        // ------------------------------------------------------------------------
        // Private declarations
        private DateTime _startTime;
        private DateTime _stopTime;
        private bool firstStart;
        private bool firstStop;

        // ------------------------------------------------------------------------
        /// <summary>Constructor for Report class</summary>
        public Report()
        {
            firstStart = true;
            firstStop = true;
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
                if (this.firstStart == true)
                {
                    this._startTime = value;
                    System.Diagnostics.Debug.WriteLine("Start Time: " + this.startTime.ToString());
                    this.firstStart = false;
                }
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
                if (this.firstStop == true)
                {
                    this._stopTime = value;
                    System.Diagnostics.Debug.WriteLine("Stop Time: " + this.stopTime.ToString());
                    TimeSpan duration = stopTime - startTime;
                    System.Diagnostics.Debug.WriteLine("Duration: " + duration.ToString());
                    this.firstStop = false;
                }
            }
        }



    }

}
