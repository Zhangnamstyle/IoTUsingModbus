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
        Timer tmr1 = new Timer();
        public int cnt;
        private ushort id;

        public GUI()
        {
            InitializeComponent();
            cnt = 0;
            if (comHandler == null)
            {
                comHandler = new ComHandler("Alexander", 121174);
                comHandler.OnResponseData += new IoTModbus.ComHandler.ResponseData(comHandler_OnResponseData);
                comHandler.OnException += new IoTModbus.ComHandler.ExceptionData(comHandler_OnException);
                comHandler.OnError += new IoTModbus.ComHandler.ErrorData(comHandler_OnError);
            }

            cnt = 0;
            tmr1.Interval = 5;
            tmr1.Tick += Tmr1_Tick;
            id = 0;
            
        }

        private void Tmr1_Tick(object sender, EventArgs e)
        {
            int num = 4;
            ushort ID = getID();
            byte unit = 1;
            ushort startAddress = 0;
            bool[] bits = new bool[num];

            if (cnt == 0)
            {
                bits[0] = true;
                bits[1] = true;
                bits[2] = true;
                bits[3] = true;

                cnt = 1;
            }
            else if(cnt == 1)
            {
                bits[0] = false;
                bits[1] = false;
                bits[2] = false;
                bits[3] = false;

                cnt = 0;
            }

            int nBytes = (byte)(num / 8 + (num % 8 > 0 ? 1 : 0));
            byte[] data = new Byte[nBytes];
            BitArray bitArray = new BitArray(bits);
            bitArray.CopyTo(data, 0);

            comHandler.send(15, ID, unit, startAddress, (byte)num, data);
            ID = getID();
            comHandler.send(1, ID, 1, 0, 4);
        }

        private void comHandler_OnError(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            ushort port;
            bool res1 = IPAddress.TryParse(txtIP.Text, out ip);
            bool res2 = ushort.TryParse(txtPort.Text, out port);
            if (!res1) MessageBox.Show("Error");
            if (!res1) MessageBox.Show("Error");
            else comHandler.connect(ip.ToString(), port);


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
            ushort ID = getID();
            comHandler.send(1, ID, 1, 0, 4);
        }

        private void btnWriteCoils_Click(object sender, EventArgs e)
        {
            int num = 4;
            ushort ID = getID();
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
            int num = 4;
            ushort ID = getID();
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
            ushort ID = getID();
            comHandler.send(3, ID, 1, 0, 4);
            cnt++;
        }

        private void btnReadDis_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            comHandler.send(2, ID, 1, 0, 4);
        }

        private void btnReadInputReg_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            comHandler.send(4, ID, 1, 0, 2);
        }

        private void btnWriteSCoil_Click(object sender, EventArgs e)
        {
            int num = 1;
            ushort ID = getID();
            byte unit = 1;
            ushort startAddress = 1;

            bool bit = true;
            byte[] data = new byte[1];
            if (bit) data[0] = 255;
            else data[0] = 0;

            comHandler.send(5, ID, unit, startAddress,(byte)num, data);
        }

        private void btnWriteSR_Click(object sender, EventArgs e)
        {
            int num = 1;
            ushort ID = getID();
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
            //comHandler.reportSlaveID(9, 1);
            tmr1.Start();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tmr1.Stop();
            comHandler.generateReport();
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }
        private ushort getID()
        {
            ushort ID = id;
            id++;
            return ID;
            
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            DialogResult dR = MessageBox.Show("This operation may take some time, Continue ?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult == DialogResult.Yes)
            {


            }
            
        }
    }
}
