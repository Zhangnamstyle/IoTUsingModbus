using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTModbus
{
    class GUIFacade
    {
        Timer tmr = new Timer();
        GUI gui;
        int cnt = 0;


        public GUIFacade(string _sName,int _sNumber)
        {
            gui = new GUI();

            tmr.Interval = 200;
            tmr.Tick += Tmr_Tick;
            tmr.Start();

            gui.EventA += OnEventB;

            Application.Run(gui);
        }

        private void OnEventB()
        {
            MessageBox.Show("This event thing worked");
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(cnt.ToString());
            cnt++;  
        }
        
    }
}
