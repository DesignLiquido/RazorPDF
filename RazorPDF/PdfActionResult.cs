using System;
using System.Web.Mvc;

namespace RazorPDF
{
    public class PdfActionResult : MvcRazorToPdf.PdfActionResult
    {
        public PdfActionResult(string viewName, object model) : base(viewName, model)
        {
            
        }

        public PdfActionResult(object model) : base(model)
        {
            
        }

        public PdfActionResult(object model, Action<iTextSharp.text.pdf.PdfWriter, iTextSharp.text.Document> configureSettings) : base(model, configureSettings)
        {
            
        }

        public PdfActionResult(string viewName, object model, Action<iTextSharp.text.pdf.PdfWriter, iTextSharp.text.Document> configureSettings) : base(viewName, model, configureSettings)
        {
            
        }
    }
}
