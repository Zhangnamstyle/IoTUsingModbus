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

        public GUI()
        {
            InitializeComponent();
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
            comHandler.sendOff();
        }

        private void btnSendOn_Click(object sender, EventArgs e)
        {
            comHandler.sendOn();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            comHandler.sendRead();
        }

    }
}
