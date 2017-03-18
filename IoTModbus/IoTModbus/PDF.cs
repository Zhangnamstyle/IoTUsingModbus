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
        public static bool createPDF(DataTable _dt)
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
                BaseFont bfHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_CACHED);
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfHead, 16, 1);

                System.Drawing.Image img = System.Drawing.Image.FromHbitmap(Properties.Resources.Modbus_IoT.GetHbitmap());
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Png);
                logo.ScaleAbsolute(125f, 17);
                doc.Add(logo);


                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_BASELINE, 0)));
                doc.Add(p);

                doc.Add(new Chunk("\n", fntHead));

                PdfPTable tbl = new PdfPTable(_dt.Columns.Count);

                BaseFont bfTbl = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_CACHED);
                iTextSharp.text.Font fntTbl = new iTextSharp.text.Font(bfHead, 16, 1);
                foreach (DataColumn dc in _dt.Columns)
                {

                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                    cell.AddElement(new Chunk(dc.ColumnName.ToUpper()));
                    tbl.AddCell(cell);
                }
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    for (int j = 0; j < _dt.Columns.Count; j++)
                    {
                        tbl.AddCell(_dt.Rows[i][j].ToString());
                    }
                }
                doc.Add(tbl);


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
