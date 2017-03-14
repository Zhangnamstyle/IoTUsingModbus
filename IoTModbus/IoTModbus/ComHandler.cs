using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    class ComHandler
    {        
        // ------------------------------------------------------------------------
        // Private declarations
        private ModbusTCP modbusTCP;
        private Report report;

        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public delegate void ExceptionData(ushort id, byte unit, byte function, byte exception);
        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public event ExceptionData OnException;
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void ResponseData(ushort id, byte unit, byte function, byte[] data);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ResponseData OnResponseData;

        internal void CallException(ushort id, byte unit, byte function, byte exception)
        {
            disconnect();
            if (OnException != null) OnException(id, unit, function, exception);
           
        }


        // ------------------------------------------------------------------------
        /// <summary>Constructor for Report class</summary>
        public ComHandler()
        {
            connect();
        }

        // ------------------------------------------------------------------------
        /// <summary>Connects to the Modbus slave</summary>
        public void connect()
        {
            report = new Report();
            modbusTCP = new ModbusTCP("192.168.1.101", 502, report);
        }

        // ------------------------------------------------------------------------
        /// <summary>Disconnect from the Modbus slave</summary>
        public void disconnect()
        {
            if(modbusTCP != null)
            {
                modbusTCP.disconnect();
                modbusTCP = null;
            }
        }


        public void sendOff()
        {
            //WRITE TEST
            byte[] test = BitConverter.GetBytes(0);
            modbusTCP.send(5,1, 1, 1, 1, test);

        }
        public void sendOn()
        {
            //WRITE TEST
            byte[] test = BitConverter.GetBytes(255);
            //modbusTCP.send(5,1, 1, 1, 1, test);
            modbusTCP.send(5, 1, 1, 16, 1,test);

        }
        public void sendRead()
        {
            modbusTCP.send(2,1, 1, 0, 4);
        }
    }
}
