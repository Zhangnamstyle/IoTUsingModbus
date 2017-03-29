using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTModbus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GUI());
            using (var wForm = new welcomeForm())
            {
                wForm.StartPosition = FormStartPosition.CenterScreen;
                DialogResult result = wForm.ShowDialog();
                if (result == DialogResult.OK)
                {

                    GUIFacade guiFacade = new GUIFacade(wForm.SName,wForm.SNumber);
                }
            }
        }
    }
}
