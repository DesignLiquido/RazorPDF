// Copyright 2014 Cigano Morrison Mendez - http://github.com/cigano
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace RazorPDF
{
    public class PdfView : IView, IViewEngine
    {
        private readonly ViewEngineResult _result;

        public PdfView(ViewEngineResult result)
        {
            _result = result;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            // generate view into string
            var sb = new System.Text.StringBuilder();
            TextWriter tw = new System.IO.StringWriter(sb);
            _result.View.Render(viewContext, tw);
            var resultCache = sb.ToString();

            var ms = new MemoryStream();
            var document = new Document();
            var pdfWriter = PdfWriter.GetInstance(document, ms);
            var worker = new HTMLWorker(document);
            document.Open();
            worker.StartDocument();

            pdfWriter.CloseStream = false;


            worker.Parse(new StringReader(resultCache));
            worker.EndDocument();
            worker.Close();
            document.CloseDocument();
            document.Close();

            // this is as close as we can get to being "success" before writing output
            // so set the content type now
            viewContext.HttpContext.Response.ContentType = "application/pdf";
            pdfWriter.Flush();
            pdfWriter.Close();

            viewContext.HttpContext.Response.BinaryWrite(ms.ToArray());
        }


        private static XmlTextReader GetXmlReader(string source)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(source);
            var stream = new MemoryStream(byteArray);

            var xtr = new XmlTextReader(stream) {WhitespaceHandling = WhitespaceHandling.None};
            return xtr;
        }

        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            throw new System.NotImplementedException();
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            throw new System.NotImplementedException();
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            _result.ViewEngine.ReleaseView(controllerContext, _result.View);
        }
    }
}
