using System;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RazorPDF
{
    public static class RazorToPdfExtensions
    {
        public static byte[] GeneratePdf(this ControllerContext context, object model = null, string viewName = null,
            Action<PdfWriter, Document> configureSettings = null)
        {
            return new RazorToPdf().GeneratePdfOutput(context, model, viewName, configureSettings);
        }
    }
}
