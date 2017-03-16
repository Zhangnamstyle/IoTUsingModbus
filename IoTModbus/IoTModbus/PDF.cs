using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace IoTModbus
{
    static class PDF
    {
        //public static bool createPDF(DataTable _dt, string _name,int sNumber)
        public static bool createPDF()
        {
            try
            {
                //Setup Of File
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                string file = "ModbusReport.pdf";
                string filePath = Path.Combine(path, file);

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                Document doc = new Document();
                doc.SetPageSize(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                //Header
                System.Drawing.Image img = System.Drawing.Image.FromHbitmap(Properties.Resources.Modbus_IoT.GetHbitmap());
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Png);
                logo.ScaleAbsolute(125f, 17);
                doc.Add(logo);


                doc.Close();
                writer.Close();
                fs.Close();



                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
