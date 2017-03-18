using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTModbus
{
    public partial class GUI : Form
    {
        ComHandler comHandler;
        private string _message;
        int cnt;

        public GUI()
        {
            InitializeComponent();
            cnt = 0;
            if (comHandler == null)
            {
                comHandler = new ComHandler();
                comHandler.OnResponseData += new IoTModbus.ComHandler.ResponseData(comHandler_OnResponseData);
                comHandler.OnException += new IoTModbus.ComHandler.ExceptionData(comHandler_OnException);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = txtIP.ToString();
            int port = Convert.ToInt16(txtPort.Text.ToString()); 
            comHandler.connect(ip,port);
        }

        private void comHandler_OnResponseData(ushort id, byte unit, byte function, byte[] data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ComHandler.ResponseData(comHandler_OnResponseData), new object[] { id, unit, function, data });
                return;
            }
            this.txtMessages.AppendText("ID: " + id.ToString() + " Unit: " + unit.ToString() + " Function: " + function.ToString() +" Values: " +ByteArrayToString(data) + "\r\n");
        }


        // ------------------------------------------------------------------------
        /// <summary>Writes the adu to the Modbus Slave</summary>
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private void comHandler_OnException(ushort id, byte unit, byte function, string exMessage)
        {
            MessageBox.Show(exMessage, "Modbus Exception");
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            comHandler.disconnect();        
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            comHandler.send(1, 1, 1, 0, 4);
        }

        private void btnWriteCoils_Click(object sender, EventArgs e)
        {
            int num = 4;
            ushort ID = 2;
            byte unit = 1;
            ushort startAddress = 0;

            bool[] bits = new bool[num];
            bits[0] = false;
            bits[1] = false;
            bits[2] = false;
            bits[3] = false;


            int nBytes = (byte)(num / 8 + (num % 8 > 0 ? 1 : 0));
            byte[] data = new Byte[nBytes];
            BitArray bitArray = new BitArray(bits);
            bitArray.CopyTo(data, 0);

            comHandler.send(15, ID, unit, startAddress, (byte)num, data);
        }

        private void btnWriteHoldings_Click(object sender, EventArgs e)
        {
            int num = 2;
            ushort ID = 3;
            byte unit = 1;
            ushort startAddress = 0;

            int[] temp = new int[num];
            for(int i = 0; i<num;i++)
            {
                temp[i] = 0;
            }

            byte[] data = new Byte[num * 2];
            for (int x = 0; x < num; x++)
            {
                byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                data[x * 2] = tempData[0];
                data[x * 2 + 1] = tempData[1];
            }

            comHandler.send(16, ID, unit, startAddress, (byte)num, data);
        }

        private void btnReadHoldings_Click(object sender, EventArgs e)
        {
            comHandler.send(3, 4, 1, 0, 32);
        }

        private void btnReadDis_Click(object sender, EventArgs e)
        {
            comHandler.send(2, 5, 1, 0, 4);
        }

        private void btnReadInputReg_Click(object sender, EventArgs e)
        {
            comHandler.send(4, 6, 1, 0, 2);
        }

        private void btnWriteSCoil_Click(object sender, EventArgs e)
        {
            int num = 1;
            ushort ID = 7;
            byte unit = 1;
            ushort startAddress = 1;

            bool bit = true;
            byte[] data = new byte[1];
            if (bit) data[0] = 255;
            else data[0] = 0;

            comHandler.send(5, ID, unit, startAddress, 1, data);
        }

        private void btnWriteSR_Click(object sender, EventArgs e)
        {
            int num = 1;
            ushort ID = 8;
            byte unit = 1;
            ushort startAddress = 1;

            int[] temp = new int[num];
            temp[0] = 32000;

            byte[] data = new Byte[num * 2];
            for (int x = 0; x < num; x++)
            {
                byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                data[x * 2] = tempData[0];
                data[x * 2 + 1] = tempData[1];
            }

            comHandler.send(6, ID, unit, startAddress, (byte)num, data);
        }

        private void btnReportSlaveID_Click(object sender, EventArgs e)
        {
            comHandler.reportSlaveID(9, 1);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            comHandler.generateReport();
        }
    }
}
