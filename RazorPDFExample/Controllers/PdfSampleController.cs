using System.Collections.Generic;
using System.Web.Mvc;
using RazorPDF;
using RazorPDFExample.Models;

namespace RazorPDFExample.Controllers
{
    public class PdfSampleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PdfResult Pdf()
        {
            // With no Model and default view name.  Pdf is always the default view name
            return new PdfResult();
        }

        public ActionResult PdfModel(string id)
        {
            // Since type is an ActionResult, we can still return an html view if something isn't right
            if (id != "yoda")
                return View("NotFound");

            // get Person
            var person = new Person { UserName = id, LuckyNumber = 7 };

            // pass in Model, then View name
            var pdf = new PdfActionResult("HtmlToPdf", person);

            // Add to the view bag
            // pdf.ViewBag.Title = "Title from ViewBag";

            return pdf;
        }

        public ActionResult PdfTake3(string id)
        {
            var person = new Person() { UserName = id, LuckyNumber = 17 };

            // return new PdfResult(person, "PdfModel");
            return new PdfActionResult("HtmlToPdf", person);
        }

        public ActionResult HtmlReport()
        {
            // Setup sample model
            var list = new List<Person>();
            for (int i = 1; i < 10; i++)
                list.Add(new Person() { UserName = "Person " + i, LuckyNumber = i });

            // Output to Pdf?
            if (Request.QueryString["format"] == "pdf")
            {
                return new PdfResult(list, "HtmlReport");
            }


            return View(list);
        }

        public ActionResult ReportSample()
        {
            var list = new List<Person>();

            for (int i = 1; i < 10; i++)
                list.Add(new Person() { UserName = "Person " + i.ToString(), LuckyNumber = i });

            var pdf = new PdfResult(list, "ReportSample");
            pdf.ViewBag.Title = "Report Title";

            return pdf;
        }
    }
}