using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTModbus
{
    class ComHandler
    {
        ModbusTCP modbusTCP;
        Report report;
        public ComHandler()
        {
            connect();
        }
        public void connect()
        {
            report = new Report();
            modbusTCP = new ModbusTCP("192.168.1.1", 80, report);
        }
        public void disconnect()
        {
            if(modbusTCP != null)
            {
                modbusTCP.disconnect();
                modbusTCP = null;
            }
        }
    }
}
