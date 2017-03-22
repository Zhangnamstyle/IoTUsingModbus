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
        public static bool createPDF(DataTable _dtFunc,DataTable _dtExce,DateTime[] _times)
        {
            try
            {
                //Setup Of PDF File
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                string file = "ModbusReport.pdf";
                string filePath = Path.Combine(path, file);

                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                Document doc = new Document();
                doc.SetPageSize(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                BaseFont bftMain = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                string username = ComHandler.Username;
                int userId = ComHandler.UserId;
                // ------------------------------------------------------------------------
                // Header
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bftMain, 16, 1);
                System.Drawing.Image img = System.Drawing.Image.FromHbitmap(Properties.Resources.Modbus_IoT.GetHbitmap());
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Png);
                logo.ScaleAbsolute(125f, 17);
                doc.Add(logo);

                // User
                Paragraph pUser = new Paragraph();
                iTextSharp.text.Font fUser = new iTextSharp.text.Font(bftMain, 8, 2,BaseColor.GRAY);
                pUser.Alignment = Element.ALIGN_RIGHT;
                pUser.Add(new Chunk("User: " + username,fUser));
                pUser.Add(new Chunk("\nID: " + userId, fUser));
                pUser.Add(new Chunk("\nDate: " +  DateTime.Now.ToString(), fUser));
                doc.Add(pUser);


                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F,BaseColor.BLACK, Element.ALIGN_BASELINE, 0)));
                doc.Add(p);


                doc.Add(new Chunk("\n", fntHead));

                // ------------------------------------------------------------------------
                // Main font definition
                iTextSharp.text.Font fntMain= new iTextSharp.text.Font(bftMain, 8, 2, BaseColor.BLACK);

                // ------------------------------------------------------------------------
                // Time used
                Paragraph pTime = new Paragraph();
                pTime.Add(new Chunk("Application was open on: " + _times[0].ToLongTimeString(), fUser));
                pTime.Add(new Chunk("\nApplication was closed on: " + _times[1].ToLongTimeString(), fUser));
                pTime.Add(new Chunk("\nApplication total time open: " + _times[2].ToLongTimeString(), fUser));
                pTime.Add(new Chunk("\nTotal time connected: " + _times[3].ToLongTimeString(), fUser));
                doc.Add(pTime);

                // ------------------------------------------------------------------------
                // Function Code Table
                PdfPTable tblFunc = new PdfPTable(_dtFunc.Columns.Count);
                foreach (DataColumn dc in _dtFunc.Columns)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                    cell.AddElement(new Chunk(dc.ColumnName.ToUpper(),fntMain));
                    tblFunc.AddCell(cell);
                }
                for (int i = 0; i < _dtFunc.Rows.Count; i++)
                {
                    for (int j = 0; j < _dtFunc.Columns.Count; j++)
                    {
                        PdfPCell dataCell = new PdfPCell();
                        dataCell.AddElement(new Chunk(_dtFunc.Rows[i][j].ToString(), fntMain));
                        tblFunc.AddCell(dataCell);
                    }
                }
                doc.Add(tblFunc);

                doc.Add(new Chunk("\n", fntMain));

                // ------------------------------------------------------------------------
                // Exception Code Table
                PdfPTable tblExcept = new PdfPTable(_dtExce.Columns.Count);
                foreach (DataColumn dc in _dtExce.Columns)
                {
                    PdfPCell columnCell = new PdfPCell();
                    columnCell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                    columnCell.AddElement(new Chunk(dc.ColumnName.ToUpper(),fntMain));
                    tblExcept.AddCell(columnCell);
                }
                for (int i = 0; i < _dtExce.Rows.Count; i++)
                {
                    for (int j = 0; j < _dtExce.Columns.Count; j++)
                    {
                        PdfPCell dataCell = new PdfPCell();
                        dataCell.AddElement(new Chunk(_dtExce.Rows[i][j].ToString(), fntMain));
                        tblExcept.AddCell(dataCell);
                    }
                }
                doc.Add(tblExcept);

                doc.Close();
                writer.Close();
                fs.Close();



                return true;
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            
        }
    }
}
