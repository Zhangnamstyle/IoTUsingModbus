using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTModbus
{
    public class GUIFacade
    {
        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        ComHandler comHandler;
        GUI gui;
        IO[] ioObj;
        digitalIO d1;
        digitalIO d2;
        digitalIO d3;
        digitalIO d4;
        analogIO a1;
        analogIO a2;

        SemaphoreSlim s = new SemaphoreSlim(1);

        private ushort id = 0;
        int cnt = 0;
        private bool first = true;

        public delegate void MessageData(byte[] adu);
        /// <summary>Exception data event. This event is called when the data is incorrect</summary>
        public event MessageData OnMessage;


        public GUIFacade(string _sName,int _sNumber)
        {
            gui = new GUI(this);
            gui.onConnectClick += new GUI.ConnectData(gui_onConnect);
            gui.onReportClick += new GUI.ReportData(gui_onReport);
            gui.onWriteSend += new GUI.WriteData(gui_onWriteSend);
            gui.onReadSend += new GUI.ReadData(gui_onReadData);

            if (comHandler == null)
            {
                comHandler = new ComHandler(_sName, _sNumber);
                comHandler.OnResponseData += new IoTModbus.ComHandler.ResponseData(comHandler_OnResponseData);
                comHandler.OnException += new IoTModbus.ComHandler.ExceptionData(comHandler_OnException);
                comHandler.OnError += new IoTModbus.ComHandler.ErrorData(comHandler_OnError);
            }

            int nAnalog = 2;
            int nDigital = 4;
            ioObj = createIOArray(nAnalog,nDigital);


            tmr.Interval = 800;
            tmr.Tick += Tmr_Tick;
           

            Application.Run(gui);
        }

        private void gui_onWriteSend(byte funcNr, ushort tId, byte unit, ushort startAddress, ushort numBits, byte[] values)
        {
            comHandler.send(funcNr, tId, unit, startAddress, numBits, values);
        }

        private void gui_onReadData(byte funcNr, ushort tId, byte unit, ushort startAddress, ushort numInputs)
        {
            comHandler.send(funcNr, tId, unit, startAddress, numInputs);
        }

        private void gui_onReport()
        {
            tmr.Stop();
            comHandler.generateReport();
        }

        private void gui_onConnect(string _ip,string _port)
        {
            gui.Cursor = Cursors.WaitCursor;
            IPAddress ip;
            ushort port;
            bool res1 = IPAddress.TryParse(_ip, out ip);
            bool res2 = ushort.TryParse(_port, out port);
            if(!res1) MessageBox.Show("The IP provided was not valid","Port Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else if(!res2) MessageBox.Show("The Port provided was not valid","Port Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
            comHandler.connect(ip.ToString(),port); //Fix toString

            if (ComHandler.Connected)
            {
                if(first)activateAnalogOut();

                if (gui.Tab == 0)
                {
                    d1 = new digitalIO(0, 0);
                    d2 = new digitalIO(1, 1);
                    d3 = new digitalIO(2, 2);
                    d4 = new digitalIO(3, 3);

                    a1 = new analogIO(0, 0);
                    a2 = new analogIO(1, 1);

                    tmr.Start();
                }

            }
            gui.Cursor = Cursors.Default;
        }

   

        private void MainLoop()
        {

            checkMultipleDI(d1, d4);
            Thread.Sleep(100);
            checkMultipleAI(a1, a2);
            Thread.Sleep(100);



        }

        private void checkMultipleAI(analogIO aStart, analogIO aEnd)
        {
            int num = 2;
            byte unit = 1;
            ushort startAddress = aStart.InputRegister;
            comHandler.send(4, getID(), unit, startAddress, (byte)num);
        }

        private void checkMultipleDI(digitalIO dStart, digitalIO dEnd)
        {
            int num = 4;
            byte unit = 1;
            ushort startAddress = dStart.InputRegister;
            comHandler.send(2, getID(), unit, startAddress, (byte)num);
        }

        private void checkSingleDI(digitalIO dIO)
        {
            int num = 1;
            byte unit = 1;
            ushort startAddress = dIO.InputRegister;
            comHandler.send(2, getID(), unit, startAddress, (byte)num);
        }
        private void checkSingleAI(analogIO aIO)
        {
            
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            MainLoop();
            System.Diagnostics.Debug.WriteLine(cnt.ToString());
            
        }


        private IO[] createIOArray(int nAnalog,int nDigital)
        {
            IO[] _ioObj = new IO[nAnalog + nDigital];
            if(nAnalog != 0 && nDigital !=0)
            {
                for(int i = 0;i<nAnalog;i++)
                {
                    _ioObj[i] = new analogIO((byte)i,(byte)i);
                }
                for (int i = nAnalog; i < nAnalog + nDigital; i++)
                {
                    _ioObj[i] = new digitalIO((byte)i, (byte)i);
                }
            }
            return _ioObj;
        }

        private void comHandler_OnResponseData(ushort id, byte unit, byte function, byte[] data,byte[] adu,ushort startAddress,ushort lenght)
        {
            int outVal = 0;

            ushort outReg = 0;
            switch (function)
            {

                case 1:
                    if (lenght <= 1)
                    {
                        if (startAddress == d1.InputRegister)
                        {
                            d1.InputValue = data[1];
                            outVal = d1.GetOutputValue();
                        }
                        else if (startAddress == d2.InputRegister)
                        {
                            d2.InputValue = data[1];
                            outVal = d2.GetOutputValue();
                        }
                    }
                    else
                    {

                    }
                    OnMessage(adu);
                    break;
                case 2:
                    if (lenght <= 1)
                    {
                        if (startAddress == d1.InputRegister)
                        {
                            d1.InputValue = data[1];
                            outVal = d1.GetOutputValue();
                            outReg = d1.OutputRegister;
                        }
                        else if (startAddress == d2.InputRegister)
                        {
                            d2.InputValue = data[1];
                            outVal = d2.GetOutputValue();
                            outReg = d2.OutputRegister;
                        }
                        else if (startAddress == d3.InputRegister)
                        {
                            d3.InputValue = data[1];
                            outVal = d3.GetOutputValue();
                            outReg = d3.OutputRegister;
                        }
                        else if (startAddress == d4.InputRegister)
                        {
                            d4.InputValue = data[1];
                            outVal = d4.GetOutputValue();
                            outReg = d4.OutputRegister;
                        }
                        byte[] outData = new byte[1];
                        outData[0] = (byte)outVal;
                        comHandler.send(5, getID(), unit, outReg, 1, outData);
                    }
                    else
                    {
                        bool[] bits = new bool[1];
                        byte[] tempData = new byte[1];
                        Buffer.BlockCopy(data, 1, tempData, 0, 1);
                        BitArray bitArray = new BitArray(tempData);
                        bits = new bool[bitArray.Count];
                        bitArray.CopyTo(bits, 0);

                        d1.InputValue = bits[0] ? 1 : 0;
                        d2.InputValue = bits[1] ? 1 : 0;
                        d3.InputValue = bits[2] ? 1 : 0;
                        d4.InputValue = bits[3] ? 1 : 0;

                        bool[] outDataBool = new bool[4];
                        outDataBool[0] = Convert.ToBoolean(d1.GetOutputValue());
                        outDataBool[1] = Convert.ToBoolean(d2.GetOutputValue());
                        outDataBool[2] = Convert.ToBoolean(d3.GetOutputValue());
                        outDataBool[3] = Convert.ToBoolean(d4.GetOutputValue());

                        int nBytes = (byte)(4 / 8 + (4 % 8 > 0 ? 1 : 0));
                        byte[] outData = new Byte[nBytes];
                        BitArray bitA = new BitArray(outDataBool);
                        bitA.CopyTo(outData, 0);

                        comHandler.send(15, getID(), unit, startAddress, 4, outData);
                    }
                    OnMessage(adu);
                    break;

                case 4:
                    if (lenght <= 1)
                    {
                        byte[] tempValue = new byte[2];
                        Buffer.BlockCopy(data, 1, tempValue, 0, 2);
                        Array.Reverse(tempValue);
                        int inVal = BitConverter.ToInt16(tempValue, 0);

                        if (startAddress == a1.InputRegister)
                        {
                            a1.InputValue = inVal;
                            outVal = a1.GetOutputValue();
                            outReg = a1.OutputRegister;
                        }
                        else if (startAddress == a2.InputRegister)
                        {
                            a2.InputValue = inVal;
                            outVal = a2.GetOutputValue();
                            outReg = a2.OutputRegister;
                        }

                        int num = 1;

                        int[] temp = new int[num];
                        temp[0] = outVal;

                        byte[] outAData = new Byte[num * 2];
                        for (int x = 0; x < num; x++)
                        {
                            byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                            outAData[x * 2] = tempData[0];
                            outAData[x * 2 + 1] = tempData[1];
                        }
                        comHandler.send(6, getID(), unit, outReg, 1, outAData);
                    }
                    else
                    {
                        byte[] tempValue1 = new byte[2];
                        byte[] tempValue2 = new byte[2];
                        Buffer.BlockCopy(data, 1, tempValue1, 0, 2);
                        Buffer.BlockCopy(data, 3, tempValue2, 0, 2);
                        Array.Reverse(tempValue1);
                        Array.Reverse(tempValue2);
                        int inVal1 = BitConverter.ToInt16(tempValue1, 0);
                        int inVal2 = BitConverter.ToInt16(tempValue2, 0);

                        a1.InputValue = inVal1;
                        a2.InputValue = inVal2;

                        

                        int[] temp = new int[2];
                        temp[0] = a1.GetOutputValue();
                        temp[1] = a2.GetOutputValue();

                        byte[] holdingData = new Byte[2 * 2];
                        for (int x = 0; x < 2; x++)
                        {
                            byte[] tempData = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)temp[x]));
                            holdingData[x * 2] = tempData[0];
                            holdingData[x * 2 + 1] = tempData[1];
                        }
                        comHandler.send(16, getID(), unit, a1.OutputRegister,2, holdingData);

                    }
                    OnMessage(adu);
                    break;
            }






            
        }

        private void comHandler_OnException(ushort id, byte unit, byte function, string exMessage)
        {
            MessageBox.Show(exMessage, "Modbus Exception");
        }
        private void comHandler_OnError(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        private ushort getID()
        {
            ushort ID = id;
            id++;
            return ID;

        }

        private void activateAnalogOut()
        {
            int num = 2;
            ushort ID = getID();
            byte unit = 1;
            ushort startAddress = 4;
            bool[] bits = new bool[num];

                bits[0] = true;
                bits[1] = true;

            int nBytes = (byte)(num / 8 + (num % 8 > 0 ? 1 : 0));
            byte[] data = new Byte[nBytes];
            BitArray bitArray = new BitArray(bits);
            bitArray.CopyTo(data, 0);

            comHandler.send(15, ID, unit, startAddress, (byte)num, data);
            first = false;
        }

    }
}
