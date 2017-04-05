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
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void ConnectData(string ip, string port);
        public event ConnectData OnConnectClick;
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public delegate void DisconnectData();
        public event DisconnectData OnDisconnectClick;
        public delegate void ReportData();
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ReportData OnReportClick;
        public delegate void WriteData(byte funcNr, byte unit, ushort startAddress, ushort numBits, byte[] values);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event WriteData OnWriteSend;
        public delegate void ReadData(byte funcNr, byte unit, ushort startAddress, ushort numInputs);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ReadData OnReadSend;
        public delegate void InputData(bool d1, bool d2, bool d3, bool d4, short a1, short a2);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event InputData OnInputChange;
        public delegate void TabData(int tabId);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event TabData OnTabChange;


        private bool pause = false;

        private string ipAdress = "000.000.0.0";
        private string port = "502";



        public GUI(GUIFacade guiFacade)
        {
            InitializeComponent();

            guiFacade.OnMessage += new GUIFacade.MessageData(guiFacade_OnMessage);
            guiFacade.OnUpdateGUIData += new GUIFacade.UpdateGUIData(guiFacade_OnUpdateGUI);
            guiFacade.OnDisconnect += new GUIFacade.DisconnectData(guiFacade_OnDisconnect);
            btnPause.Enabled = true;
            btnResume.Enabled = false;
            cboIP.Enabled = false;
            btnRefresh.Enabled = false;

            disableControls();

            txtMessages.Font = new Font(txtMessages.Font.FontFamily, 8);
        }

        #region GUIFacade Events
        private void guiFacade_OnUpdateGUI(byte function, ushort lenght, byte[] data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new GUIFacade.UpdateGUIData(guiFacade_OnUpdateGUI), new object[] { function, lenght, data });
                return;
            }
            bool[] bits;
            byte[] tempValue1 = new byte[2];
            byte[] tempValue2 = new byte[2];

            switch (function)
            {
                case 1:
                    bits = toBoolBits(data);

                    txtReadCoilsV1.Text = Convert.ToString(bits[0] ? 1 : 0);
                    txtReadCoilsV2.Text = Convert.ToString(bits[1] ? 1 : 0);
                    txtReadCoilsV3.Text = Convert.ToString(bits[2] ? 1 : 0);
                    txtReadCoilsV4.Text = Convert.ToString(bits[3] ? 1 : 0);
                    break;
                case 2:
                    bits = toBoolBits(data);

                    txtReadDV1.Text = Convert.ToString(bits[0] ? 1 : 0);
                    txtReadDV2.Text = Convert.ToString(bits[1] ? 1 : 0);
                    txtReadDV3.Text = Convert.ToString(bits[2] ? 1 : 0);
                    txtReadDV4.Text = Convert.ToString(bits[3] ? 1 : 0);
                    break;
                case 3:
                    Buffer.BlockCopy(data, 1, tempValue1, 0, 2);
                    Buffer.BlockCopy(data, 3, tempValue2, 0, 2);
                    Array.Reverse(tempValue1);
                    Array.Reverse(tempValue2);
                    txtReadHV1.Text = BitConverter.ToInt16(tempValue1, 0).ToString();
                    txtReadHV2.Text = BitConverter.ToInt16(tempValue2, 0).ToString();
                    break;
                case 4:
                    Buffer.BlockCopy(data, 1, tempValue1, 0, 2);
                    Buffer.BlockCopy(data, 3, tempValue2, 0, 2);
                    Array.Reverse(tempValue1);
                    Array.Reverse(tempValue2);
                    txtReadIRegV1.Text = BitConverter.ToInt16(tempValue1, 0).ToString();
                    txtReadIRegV2.Text = BitConverter.ToInt16(tempValue2, 0).ToString();
                    break;
            }
        }


        
        private void guiFacade_OnDisconnect()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new GUIFacade.DisconnectData(guiFacade_OnDisconnect), new object[] { });
                return;
            }
            disableControls();
        }

        private void guiFacade_OnMessage(byte[] adu)
        {
            if (!pause)
            {
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
        #endregion
        #region Button Events
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string ip = "000.000.0.0";
            string port = txtPort.Text.ToString();
            if (rdoAuto.Checked)
            {
                if (cboIP.Items.Count > 0) ip = cboIP.SelectedItem.ToString();
            }
            else if (rdoManual.Checked)
            {
                ip = txtIP.Text.ToString();
            }
            if (ip != "000.000.0.0")
            {
                if (OnConnectClick != null) OnConnectClick(ip, port);
                if (ComHandler.Connected)
                {
                    enableControls();
                    if (OnTabChange != null) OnTabChange(tbcMain.SelectedIndex);
                }
            }
            else MessageBox.Show("No IP inputted");
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (OnDisconnectClick != null) OnDisconnectClick();
        }

        private void btnReadCoils_Click(object sender, EventArgs e)
        {
            ushort num = isNumbericuShort(txtReadCoilsNum.Text.ToString());
            if (num > 0 && num <= 4)
            {
                ushort startAddress;
                if (ushort.TryParse(txtReadCoilsStartA.Text.ToString(), out startAddress))
                {
                    if (OnReadSend != null) OnReadSend(1, getUnit(), startAddress, num);
                }
                else MessageBox.Show("Not a valid Start Address", "Error");
            }
            else MessageBox.Show("Textbox num has not a valid number", "Error");
        }

        private void btnWriteCoils_Click(object sender, EventArgs e)
        {
            ushort num = isNumbericuShort(txtWriteCNum.Text.ToString());
            if (num > 0 && num <= 4)
            {
                ushort startAddress;
                if (ushort.TryParse(txtWriteCStartA.Text.ToString(), out startAddress))
                {
                    bool[] bits = new bool[num];
                    switch (num)
                    {
                        case 1:
                            bits[0] = chkWriteCV1.Checked;
                            break;
                        case 2:
                            bits[0] = chkWriteCV1.Checked;
                            bits[1] = chkWriteCV2.Checked;
                            break;
                        case 3:
                            bits[0] = chkWriteCV1.Checked;
                            bits[1] = chkWriteCV2.Checked;
                            bits[2] = chkWriteCV3.Checked;
                            break;
                        case 4:
                            bits[0] = chkWriteCV1.Checked;
                            bits[1] = chkWriteCV2.Checked;
                            bits[2] = chkWriteCV3.Checked;
                            bits[3] = chkWriteCV4.Checked;
                            break;
                    }
                    int nBytes = (byte)(num / 8 + (num % 8 > 0 ? 1 : 0));
                    byte[] data = new Byte[nBytes];
                    BitArray bitArray = new BitArray(bits);
                    bitArray.CopyTo(data, 0);

                    if (OnWriteSend != null) OnWriteSend(15, getUnit(), startAddress, num, data);

                }
                else MessageBox.Show("Not a valid Start Address", "Error");
            }
            else MessageBox.Show("Textbox num has not a valid number", "Error");



        }

        private void btnWriteHoldings_Click(object sender, EventArgs e)
        {
            ushort num = isNumbericuShort(txtWriteHNum.Text.ToString());
            if (num > 0 && num <= 2)
            {
                ushort startAddress;
                if (ushort.TryParse(txtWriteHStartA.Text.ToString(), out startAddress))
                {
                    short[] temp = new short[num];
                    bool error = false;
                    short tempval;
                    short tempval1;
                    short tempval2;
                    switch (num)
                    {
                        case 1:
                            if (short.TryParse(txtWriteHV1.Text.ToString(), out tempval))
                            {
                                temp[0] = tempval;
                            }
                            else
                            {
                                MessageBox.Show("Not a valid numeric value");
                                error = true;
                            }
                            break;
                        case 2:
                            if (short.TryParse(txtWriteHV1.Text.ToString(), out tempval1) && (short.TryParse(txtWriteHV2.Text.ToString(), out tempval2)))
                            {
                                temp[0] = tempval1;
                                temp[1] = tempval2;
                            }
                            else
                            {
                                MessageBox.Show("Not a valid numeric value");
                                error = true;
                            }
                            break;
                    }
                    if (!error)
                    {
                        byte[] data = new Byte[num * 2];
                        for (int x = 0; x < num; x++)
                        {
                            byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                            data[x * 2] = tempData[0];
                            data[x * 2 + 1] = tempData[1];
                        }
                        if (OnWriteSend != null) OnWriteSend(16, getUnit(), startAddress, (byte)num, data);
                    }

                }
                else MessageBox.Show("Not a valid Start Address", "Error");
            }
            else MessageBox.Show("Textbox num has not a valid number", "Error");


        }

        private void btnReadHoldings_Click(object sender, EventArgs e)
        {
            ushort num = isNumbericuShort(txtReadHNum.Text.ToString());
            if (num > 0 && num <= 2)
            {
                ushort startAddress;
                if (ushort.TryParse(txtReadHStartA.Text.ToString(), out startAddress))
                {
                    if (OnReadSend != null) OnReadSend(3, getUnit(), startAddress, num);
                }
                else MessageBox.Show("Not a valid Start Address", "Error");
            }
            else MessageBox.Show("Textbox num has not a valid number", "Error");
        }

        private void btnReadDis_Click(object sender, EventArgs e)
        {
            ushort num = isNumbericuShort(txtReadDNum.Text.ToString());
            if (num > 0 && num <= 4)
            {
                ushort startAddress;
                if (ushort.TryParse(txtReadDStartA.Text.ToString(), out startAddress))
                {
                    if (OnReadSend != null) OnReadSend(2, getUnit(), startAddress, num);
                }
                else MessageBox.Show("Not a valid Start Address", "Error");
            }
            else MessageBox.Show("Textbox num has not a valid number", "Error");

        }

        private void btnReadInputReg_Click(object sender, EventArgs e)
        {
            ushort num = isNumbericuShort(txtReadIRegNum.Text.ToString());
            if (num > 0 && num <= 2)
            {
                ushort startAddress;
                if (ushort.TryParse(txtReadIRegStartA.Text.ToString(), out startAddress))
                {
                    if (OnReadSend != null) OnReadSend(4, getUnit(), startAddress, num);
                }
                else MessageBox.Show("Not a valid Start Address", "Error");
            }
            else MessageBox.Show("Textbox num has not a valid number", "Error");
        }

        private void btnWriteSCoil_Click(object sender, EventArgs e)
        {
            int num = 1;
            ushort startAddress;
            if (ushort.TryParse(txtWriteSCStartA.Text.ToString(), out startAddress))
            {
                bool bit = chkWriteSCV1.Checked;
                byte[] data = new byte[1];
                if (bit) data[0] = 255;
                else data[0] = 0;

                if (OnWriteSend != null) OnWriteSend(5, getUnit(), startAddress, (byte)num, data);
            }
            else MessageBox.Show("Not a valid Start Address", "Error");
        }

        private void btnWriteSR_Click(object sender, EventArgs e)
        {
            int num = 1;

            ushort startAddress;
            if (ushort.TryParse(txtWriteSHStartA.Text.ToString(), out startAddress))
            {
                short[] temp = new short[num];
                bool error = false;

                short tempval;

                if (short.TryParse(txtWriteSHV.Text.ToString(), out tempval))
                {
                    temp[0] = tempval;
                }
                else
                {
                    MessageBox.Show("Not a valid numeric value");
                    error = true;
                }

                if (!error)
                {
                    byte[] data = new Byte[num * 2];
                    for (int x = 0; x < num; x++)
                    {
                        byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                        data[x * 2] = tempData[0];
                        data[x * 2 + 1] = tempData[1];
                    }

                    if (OnWriteSend != null) OnWriteSend(6, getUnit(), startAddress, (byte)num, data);
                }

            }
            else MessageBox.Show("Not a valid Start Address", "Error");
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (OnReportClick != null) OnReportClick();
        }
        #endregion
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
            if (rdoAuto.Checked)
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
            if (rdoManual.Checked)
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

                if (OnInputChange != null) OnInputChange(d1, d2, d3, d4, a1, a2);
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

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnTabChange != null) OnTabChange(tbcMain.SelectedIndex);
        }

        private void disableControls()
        {
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            tbcMain.Enabled = false;
            tbpSimulator.BackColor = SystemColors.ControlDark;
        }

        public void enableControls()
        {
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            tbcMain.Enabled = true;
            tbpSimulator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(211)))), ((int)(((byte)(0)))));
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

        public byte getUnit()
        {
            byte _unit;
            bool res = byte.TryParse(this.txtUnit.Text.ToString(), out _unit);
            if (res) return _unit;
            else return 1;
        }
        public ushort isNumbericuShort(string s)
        {
            ushort v;
            if (ushort.TryParse(s, out v))
            {
                return v;
            }
            else return 0;
        }
        private bool[] toBoolBits(byte[] data)
        {
            byte[] tempData = new byte[1];
            Buffer.BlockCopy(data, 1, tempData, 0, 1);
            BitArray bitArray = new BitArray(tempData);
            bool[] tempBits = new bool[bitArray.Count];
            bitArray.CopyTo(tempBits, 0);

            return tempBits;

        }
    }
}

