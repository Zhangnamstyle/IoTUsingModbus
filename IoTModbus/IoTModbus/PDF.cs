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
        /// ------------------------------------------------------------------------
        ///<summary>Creates a PDF report on the desktop.</summary>
        ///<param name="_dtFunc">DataTable with data on Function Calls.</param>
        ///<param name="_dtExce">DataTable with data on Modbus Exceptions.</param>
        ///<param name="_times">Array of DateTimes.</param>
        public static bool createPDF(DataTable _dtFunc,DataTable _dtExce,DateTime[] _times)
        {
            try
            {
                
                //Setup Of PDF File
                string path = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                string file = "ModbusReport.pdf";
                string filePath = Path.Combine(path, file);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    BaseFont bftMain = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_BASELINE, 0)));
                    float[] widths = new float[] { 11.0F, 36.0F, 14.0F, 14.0F, 25.0F };

                    string username = ComHandler.Username;
                    int userId = ComHandler.UserId;
                    // ------------------------------------------------------------------------
                    // Header
                    iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bftMain, 16, 1);
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Properties.Resources.Modbus_IoT, System.Drawing.Imaging.ImageFormat.Jpeg);
                    logo.ScaleAbsolute(250f, 35);
                    doc.Add(logo);

                    // User
                    Paragraph pUser = new Paragraph();
                    iTextSharp.text.Font fUser = new iTextSharp.text.Font(bftMain, 8, 2, BaseColor.GRAY);
                    pUser.Alignment = Element.ALIGN_RIGHT;
                    pUser.Add(new Chunk("User: " + username, fUser));
                    pUser.Add(new Chunk("\nID: " + userId, fUser));
                    pUser.Add(new Chunk("\nDate: " + DateTime.Now.ToString(), fUser));
                    doc.Add(pUser);

                    doc.Add(p);

                    // ------------------------------------------------------------------------
                    // Main font definition
                    iTextSharp.text.Font fntMain = new iTextSharp.text.Font(bftMain, 8, 2, BaseColor.BLACK);

                    // ------------------------------------------------------------------------
                    // Time used
                    Paragraph pTime = new Paragraph();
                    pTime.Alignment = Element.ALIGN_CENTER;
                    pTime.Add(new Chunk("Application was open on: " + _times[0].ToLongTimeString(), fntMain));
                    pTime.Add(Chunk.TABBING);
                    pTime.Add(new Chunk("Application was closed on: " + _times[1].ToLongTimeString(), fntMain));
                    pTime.Add(new Chunk("\nApplication was open for: " + _times[2].ToLongTimeString(), fntMain));
                    pTime.Add(Chunk.TABBING);
                    pTime.Add(new Chunk("Total Time Connected: " + _times[3].ToLongTimeString(), fntMain));
                    doc.Add(pTime);

                    doc.Add(new Paragraph("\n"));

                    // ------------------------------------------------------------------------
                    // Function Code Table
                    PdfPTable tblFunc = new PdfPTable(_dtFunc.Columns.Count);
                    tblFunc.WidthPercentage = 90.0F;
                    
                    tblFunc.SetWidths(widths);
                    foreach (DataColumn dc in _dtFunc.Columns)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                        Paragraph p1 = new Paragraph(new Chunk(dc.ColumnName.ToUpper(), fntMain));
                        p1.Alignment = Element.ALIGN_CENTER;
                        cell.AddElement(p1);
                        tblFunc.AddCell(cell);
                    }
                    for (int i = 0; i < _dtFunc.Rows.Count; i++)
                    {
                        for (int j = 0; j < _dtFunc.Columns.Count; j++)
                        {
                            PdfPCell dataCell = new PdfPCell();
                            Paragraph p1 = new Paragraph(new Chunk(_dtFunc.Rows[i][j].ToString(), fntMain));
                            p1.Alignment = Element.ALIGN_RIGHT;
                            dataCell.AddElement(p1);
                            tblFunc.AddCell(dataCell);
                        }
                    }
                    doc.Add(tblFunc);

                    doc.Add(new Chunk("\n", fntMain));

                    // ------------------------------------------------------------------------
                    // Exception Code Table
                    PdfPTable tblExcept = new PdfPTable(_dtExce.Columns.Count);
                    tblExcept.WidthPercentage = 90.0F;
                    tblExcept.SetWidths(widths);
                    foreach (DataColumn dc in _dtExce.Columns)
                    {
                        PdfPCell columnCell = new PdfPCell();
                        columnCell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                        Paragraph p1 = new Paragraph(new Chunk(dc.ColumnName.ToUpper(), fntMain));
                        p1.Alignment = Element.ALIGN_CENTER;
                        columnCell.AddElement(p1);
                        tblExcept.AddCell(columnCell);
                    }
                    for (int i = 0; i < _dtExce.Rows.Count; i++)
                    {
                        for (int j = 0; j < _dtExce.Columns.Count; j++)
                        {
                            PdfPCell dataCell = new PdfPCell();
                            Paragraph p1 = new Paragraph(new Chunk(_dtExce.Rows[i][j].ToString(), fntMain));
                            p1.Alignment = Element.ALIGN_RIGHT;
                            dataCell.AddElement(p1);
                            tblExcept.AddCell(dataCell);
                        }
                    }
                    doc.Add(tblExcept);

                    doc.Close();

                    return true;
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
                return false;
            }
            
        }
    }
}
