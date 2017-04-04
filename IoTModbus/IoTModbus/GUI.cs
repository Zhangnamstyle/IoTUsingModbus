using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTModbus
{
    public partial class GUI : Form
    {
        Timer tmr1 = new Timer();
        private bool pause = false;
        private static int tab;

        public delegate void ConnectData(string ip,string port);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ConnectData onConnectClick;
        public delegate void ReportData();
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ReportData onReportClick;
        public delegate void WriteData(byte funcNr, ushort tId, byte unit, ushort startAddress, ushort numBits, byte[] values);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event WriteData onWriteSend;
        public delegate void ReadData(byte funcNr, ushort tId, byte unit, ushort startAddress, ushort numInputs);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ReadData onReadSend;
        public delegate void InputData(bool d1,bool d2,bool d3,bool d4,short a1,short a2);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event InputData onInputChange;



        int cnt = 0;
        

        public GUI(GUIFacade guiFacade)
        {
            InitializeComponent();

            guiFacade.OnMessage += new GUIFacade.MessageData(guiFacade_OnMessage);
            btnPause.Enabled = true;
            btnResume.Enabled = false;

            cboIP.Enabled = false;
            btnRefresh.Enabled = false;
            pnl1.Enabled = false;
            pnl2.Enabled = false;
            trkA1.Enabled = false;
            trkA2.Enabled = false;

            txtMessages.Font = new Font(txtMessages.Font.FontFamily, 8);


            //cnt = 0;
            //tmr1.Interval = 5;
            //tmr1.Tick += Tmr1_Tick;
            //id = 0;

        }

        private void guiFacade_OnMessage(byte[] adu)
        {
            if (!pause) { 
                string sOut = "";
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new GUIFacade.MessageData(guiFacade_OnMessage), new object[] { adu });
                return;
            }
            if (rdoHex.Checked)
            {
                sOut = ByteArrayToHexString(adu);
            }
            else if (rdoBinary.Checked)
            {
                sOut = ByteArrayToBinaryString(adu);
            }
            txtMessages.AppendText(sOut + "\n");
            }
        }

      
        #region Button Events
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (tbcMain.SelectedTab == tbpSimulator) tab = 0;
            else tab = 1;
            string ip = "000.000.0.0";
            string port = txtPort.Text.ToString();
           if(rdoAuto.Checked)
            {
                if(cboIP.Items.Count > 0) ip = cboIP.SelectedItem.ToString();
            }
           else if(rdoManual.Checked)
            {
                ip = txtIP.Text.ToString();
            }
            if (ip != "000.000.0.0")
            {
                onConnectClick(ip, port);
                if (ComHandler.Connected) tbcMain.Enabled = true;
            }
            else MessageBox.Show("No IP inputted");
        }

       
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            onReadSend(1, ID, 1, 0, 4);
        }

        private void btnWriteCoils_Click(object sender, EventArgs e)
        {
            int num = 4;
            ushort ID = getID();
            byte unit = 1;
            ushort startAddress = 50;

            bool[] bits = new bool[num];
            bits[0] = true;
            bits[1] = false;
            bits[2] = false;
            bits[3] = false;

            
            int nBytes = (byte)(num / 8 + (num % 8 > 0 ? 1 : 0));
            byte[] data = new Byte[nBytes];
            BitArray bitArray = new BitArray(bits);
            bitArray.CopyTo(data, 0);

            onWriteSend(15, ID, unit, startAddress, (byte)num, data);
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

            onWriteSend(16, ID, unit, startAddress, (byte)num, data);
        }

        private void btnReadHoldings_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            onReadSend(3, ID, 1, 0, 4);
            cnt++;
        }

        private void btnReadDis_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            onReadSend(2, ID, 1, 0, 4);
        }

        private void btnReadInputReg_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            onReadSend(4, ID, 1, 0, 2);
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

            onWriteSend(5, ID, unit, startAddress,(byte)num, data);
        }

        private void btnWriteSR_Click(object sender, EventArgs e)
        {
            int num = 1;
            ushort ID = getID();
            byte unit = 1;
            ushort startAddress = 100;

            int[] temp = new int[num];
            temp[0] = 32000;

            byte[] data = new Byte[num * 2];
            for (int x = 0; x < num; x++)
            {
                byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                data[x * 2] = tempData[0];
                data[x * 2 + 1] = tempData[1];
            }

            onWriteSend(6, ID, unit, startAddress, (byte)num, data);
        }

        private void btnReportSlaveID_Click(object sender, EventArgs e)
        {
            //comHandler.reportSlaveID(9, 1);
            tmr1.Start();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            onReportClick();
        }
        #endregion

        private ushort getID()
        {
            ushort ID = 2;
            //ushort ID = id;
            //id++;
            return ID;
            
        }

        public int Tab
        { get { return tab; } }

        #region Conversion Methods
        // ------------------------------------------------------------------------
        /// <summary>Converts a byte array into a hexadecimal string</summary>
        private static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        // ------------------------------------------------------------------------
        /// <summary>Converts a byte array into a binary string</summary>
        private static string ByteArrayToBinaryString(byte[] ba)
        {
            StringBuilder binary = new StringBuilder(ba.Length * 8);
            foreach (byte b in ba)
                binary.Append(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
            binary.Append("\n");
            return binary.ToString();
        }
        #endregion


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            scanForDevice();
        }

        private void rdoAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoAuto.Checked)
            {
                rdoManual.Checked = false;
                cboIP.Enabled = true;
                btnRefresh.Enabled = true;

                txtIP.Enabled = false;

                scanForDevice();
            }
        }

        private void rdoManual_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoManual.Checked)
            {
                rdoAuto.Checked = false;
                txtIP.Enabled = true;

                cboIP.Enabled = false;
                btnRefresh.Enabled = false;
            }
        }

        private void scanForDevice()
        {

            DialogResult dR = MessageBox.Show("This operation may take some time, Continue ?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dR == DialogResult.Yes)
            {
                try
                {

                    List<string> list = new List<string>();
                    for (int i = 1; i < 255; i++)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        var hostname = "192.168.1." + i;
                        var port = Convert.ToInt16(txtPort.Text);
                        var timeout = TimeSpan.FromSeconds(0.01);
                        var client = new TcpClient();
                        if (!client.ConnectAsync(hostname, port).Wait(timeout))
                        {
                            System.Diagnostics.Debug.Write(hostname + " is not open \r\n");
                        }
                        else
                        {
                            list.Add(hostname);
                            client.Close();
                        }

                    }
                    this.Cursor = Cursors.Default;
                    if (list.Count < 1)
                    {

                        MessageBox.Show("No Slaves Found", "Scan Completed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cboIP.DataSource = null;
                        
                    }
                    else
                    {
                        string message;
                        if (list.Count == 1)
                        {
                            message = string.Format("{0} Slave found", list.Count);
                        }
                        else
                        {
                            message = string.Format("{0} Slaves found", list.Count);
                        }

                        MessageBox.Show(message, "Scan Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        cboIP.DataSource = list;
                        
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            } 
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            pause = true;
            btnResume.Enabled = true;
            btnPause.Enabled = false;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            pause = false;
            btnPause.Enabled = true;
            btnResume.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMessages.Clear();
        }

        private void tpgValues_Click(object sender, EventArgs e)
        {

        }
        #region Manual Control
        private void chkControl_CheckedChanged(object sender, EventArgs e)
        {
            if (chkControl.Checked)
            {
                GUIFacade.ManualOverride = true;
                inputChanged();
                pnl1.Enabled = true;
                pnl2.Enabled = true;
                trkA1.Enabled = true;
                trkA2.Enabled = true;
            }
            else
            {
                GUIFacade.ManualOverride = false;
                pnl1.Enabled = false;
                pnl2.Enabled = false;
                trkA1.Enabled = false;
                trkA2.Enabled = false;
            }
        }
 
        private void inputChanged()
        {
            if (chkControl.Checked)
            {
                bool d1 = rdoD1.Checked;
                bool d2 = rdoD2.Checked;
                bool d3 = rdoD3.Checked;
                bool d4 = rdoD4.Checked;

                short a1 = (short)trkA1.Value;
                short a2 = (short)trkA2.Value;

                onInputChange(d1, d2, d3, d4, a1, a2);
            }
        }

        private void rdo01_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo01.Checked)
            {
                inputChanged();
                ledDO1.Image = Properties.Resources.greenOff;
                ledDO2.Image = Properties.Resources.greenOff;
            }
        }
        private void rdo02_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo02.Checked)
            {
                inputChanged();
                ledDO3.Image = Properties.Resources.greenOff;
                ledDO4.Image = Properties.Resources.greenOff;
            }
        }

        private void rdoD1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoD1.Checked)
            {
                inputChanged();
                ledDO1.Image = Properties.Resources.greenOn;
                ledDO2.Image = Properties.Resources.greenOff;
            }
        }

 
        private void rdoD2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoD2.Checked)
            {
                inputChanged();
                ledDO1.Image = Properties.Resources.greenOff;
                ledDO2.Image = Properties.Resources.greenOn;
            }
        }

        private void rdoD3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoD3.Checked)
            {
                inputChanged();
                ledDO3.Image = Properties.Resources.greenOn;
                ledDO4.Image = Properties.Resources.greenOff;
            }
        }



        private void rdoD4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoD4.Checked)
            {
                inputChanged();
                ledDO3.Image = Properties.Resources.greenOff;
                ledDO4.Image = Properties.Resources.greenOn;
            }
        }

        private void trkA1_Scroll(object sender, EventArgs e)
        {
            inputChanged();
            if (trkA1.Value <= -10) ledAO1.Image = Properties.Resources.redOn;
            else if (trkA1.Value >= 10) ledAO1.Image = Properties.Resources.greenOn;
            else ledAO1.Image = Properties.Resources.greyOff;
        }

        private void trkA2_Scroll(object sender, EventArgs e)
        {
            inputChanged();
            if (trkA2.Value <= -10) ledAO2.Image = Properties.Resources.redOn;
            else if (trkA2.Value >= 10) ledAO2.Image = Properties.Resources.greenOn;
            else ledAO2.Image = Properties.Resources.greyOff;
        }
        #endregion
    }
}
