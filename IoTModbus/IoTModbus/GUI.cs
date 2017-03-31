using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public delegate void ConnectData(string ip,string port);
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ConnectData onConnectClick;
        public delegate void ReportData();
        /// <summary>Response data event. This event is called when new data arrives</summary>
        public event ReportData onReportClick;


        int cnt = 0;
        

        public GUI(GUIFacade guiFacade)
        {
            InitializeComponent();

            guiFacade.OnMessage += new GUIFacade.MessageData(guiFacade_OnMessage);
            
            //cnt = 0;
            //tmr1.Interval = 5;
            //tmr1.Tick += Tmr1_Tick;
            //id = 0;
            
        }

        private void guiFacade_OnMessage(string message)
        {
            string stringOut =  "";
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new GUIFacade.MessageData(guiFacade_OnMessage), new object[] { message });
                return;
            }
            if (rdoHex.Checked)
            {
                stringOut = message;
            }
            else if (rdoBinary.Checked)
            {
                //BitArray bitArray = new BitArray(message);
                //bits = new bool[bitArray.Count];
                //bitArray.CopyTo(bits, 0);
            }
            else if(rdoASCII.Checked)
            {
                try
                {
                    string ascii = string.Empty;

                    for (int i = 0; i < message.Length; i += 2)
                    {
                        String hs = string.Empty;

                        hs = message.Substring(i, 2);
                        uint decval = System.Convert.ToUInt32(hs, 16);
                        char character = System.Convert.ToChar(decval);
                        ascii += character;

                    }

                    stringOut = ascii;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
        
            txtMessages.AppendText(stringOut + "\n");
        }

        private void Tmr1_Tick(object sender, EventArgs e)
        {
            int num = 4;
            ushort ID = getID();
            byte unit = 1;
            ushort startAddress = 50;
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

            //comHandler.send(15, ID, unit, startAddress, (byte)num, data);
            ID = getID();
            //comHandler.send(1, ID, 1, 0, 4);
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
           string ip = "000.000.0.0";
            string port = txtPort.Text.ToString();
           if(rdoAuto.Checked)
            {
                ip = cboIP.SelectedItem.ToString();
            }
           else if(rdoManual.Checked)
            {
                ip = txtIP.Text.ToString();
            }
            onConnectClick(ip, port);
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


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            //comHandler.send(1, ID, 1, 0, 4);
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

            //comHandler.send(15, ID, unit, startAddress, (byte)num, data);
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

            //comHandler.send(16, ID, unit, startAddress, (byte)num, data);
        }

        private void btnReadHoldings_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            //comHandler.send(3, ID, 1, 0, 4);
            cnt++;
        }

        private void btnReadDis_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            //comHandler.send(2, ID, 1, 0, 4);
        }

        private void btnReadInputReg_Click(object sender, EventArgs e)
        {
            ushort ID = getID();
            //comHandler.send(4, ID, 1, 0, 2);
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

            //comHandler.send(5, ID, unit, startAddress,(byte)num, data);
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

            //comHandler.send(6, ID, unit, startAddress, (byte)num, data);
        }

        private void btnReportSlaveID_Click(object sender, EventArgs e)
        {
            //comHandler.reportSlaveID(9, 1);
            tmr1.Start();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            onReportClick();
            //comHandler.generateReport();
        }


        private ushort getID()
        {
            ushort ID = 2;
            //ushort ID = id;
            //id++;
            return ID;
            
        }

        private void btnScan_Click(object sender, EventArgs e)
        {

                DialogResult dR = MessageBox.Show("This operation may take some time, Continue ?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dR == DialogResult.Yes)
                {
                try {
                    
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
                    this.Cursor = Cursors.IBeam;
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

                        MessageBox.Show( message,"Scan Completed", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        cboIP.DataSource = list;
                    } 
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            
        }

        
    }
}
