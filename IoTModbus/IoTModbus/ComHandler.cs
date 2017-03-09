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
            modbusTCP = new ModbusTCP("192.168.1.101", 502, report);
        }
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
            modbusTCP.send(5,1, 1, 0, 1, test);

        }
        public void sendOn()
        {
            //WRITE TEST
            byte[] test = BitConverter.GetBytes(255);
            modbusTCP.send(5,1, 1, 0, 1, test);

        }
        public void sendRead()
        {
            modbusTCP.send(2,1, 1, 0, 4);
        }
    }
}
