using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTModbus
{
    public partial class GUI : Form
    {
        ComHandler comHandler;
        private string _message;
        private int cnt;
        Timer tmr1;

        public GUI()
        {
            InitializeComponent();
            cnt = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (comHandler == null)
            {
                comHandler = new ComHandler();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if(comHandler != null)
            {
                comHandler.disconnect();
                comHandler = null;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            tmr1 = new Timer();
            tmr1.Interval = 1000;
            tmr1.Tick += Tmr1_Tick;
            tmr1.Start();
            
        }

        private void Tmr1_Tick(object sender, EventArgs e)
        {
            if (cnt == 0)
            {
                comHandler.sendOn();
                cnt = 1;
            }
            else if(cnt == 1)
            {
                comHandler.sendOff();
                cnt = 0;
            }

        }

        private void btnSendOn_Click(object sender, EventArgs e)
        {
            tmr1.Stop();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            comHandler.sendRead();
        }

    }
}
