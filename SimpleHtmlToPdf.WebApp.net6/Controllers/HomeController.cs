using Microsoft.AspNetCore.Mvc;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.Settings;
using SimpleHtmlToPdf.Settings.Enums;
using SimpleHtmlToPdf.UnmanagedHandler;

namespace SimpleHtmlToPdf.WebApp.net6.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IConverter converter)
        {
            Converter = converter;
        }

        private IConverter Converter { get; }

        public IActionResult TestPDF()
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Landscape,
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = "<html><body>Test</body></html>",
                        WebSettings = { DefaultEncoding = "utf-8" },
                    },
                }
            };

            var pdf = Converter.Convert(doc);
            return File(pdf, "application/pdf", "Test.pdf");
        }
    }
}