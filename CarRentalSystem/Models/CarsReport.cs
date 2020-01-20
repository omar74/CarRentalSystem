using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CarRentalSystem.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CarCarRentalSystemRental.Models
{
    public class CarsReport
    {
        #region Declaration
        int totalCoulumn = 8;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(8);
        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Car> _cars = new List<Car>();

        #endregion
        public byte[] prepareReport(List<Car> cars)
        {
            _cars = cars;
            #region
            _document = new Document(PageSize.A4,0f,0f,0f,0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(10f, 10f,10f, 10f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            _fontStyle = FontFactory.GetFont("Tahoma",8f,1);
            PdfWriter.GetInstance(_document,_memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f,50f,50f,50f,50f,50f,50f,50f});

            #endregion
            ReportHeder();
            reportBody();
            _pdfTable.HeaderRows = 7;
            _document.Add(_pdfTable);
           
            _document.Close();
            return _memoryStream.ToArray();
        }
         private void ReportHeder()
        {
            _fontStyle = FontFactory.GetFont("Tahoma",11f,1);
            _pdfCell = new PdfPCell(new Phrase("Car Rental",_fontStyle));
            _pdfCell.Colspan = totalCoulumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.BackgroundColor = BaseColor.WHITE;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
        }
        private void reportBody()
        {

            #region Table Header
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfCell = new PdfPCell(new Phrase("ID", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("name", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("model", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("color", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("number of chairs", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("rental Amount", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Category", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("image", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();
            #endregion
            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            int serial = 1;
            foreach(Car car in _cars )
            {
                _pdfCell = new PdfPCell(new Phrase(serial ++.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(car.Name, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(car.Model, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(car.color, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(car.NumberOfChairs.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(car.RentAmount.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(car.categorytypeid.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _pdfTable.AddCell(_pdfCell);
                string logopath = System.Web.HttpContext.Current.Server.MapPath(car.ImagePath);
                Image img = Image.GetInstance(logopath);

                _pdfCell = new PdfPCell(new Phrase(car.ImagePath, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfCell.AddElement(img);
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
            #endregion
        }
    }
}