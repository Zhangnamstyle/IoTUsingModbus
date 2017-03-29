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
    public partial class welcomeForm : Form
    {
        private static string sName;
        private static int sNumber;
        public welcomeForm()
        {          
            InitializeComponent();
            picLogo.Image = Properties.Resources.Modbus_IoT;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(txtName.TextLength > 0)
            {
                sName = txtName.Text;
                bool isNumber = int.TryParse(txtSNumber.Text,out  sNumber);
                if(isNumber)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please input a student number","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please input a name","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public string SName
        {
            get { return sName; }
        }
        public int SNumber
        {
            get { return sNumber; }
        }
    }
}
