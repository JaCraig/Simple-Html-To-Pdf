using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.Settings;
using SimpleHtmlToPdf.Settings.Enums;
using SimpleHtmlToPdf.UnmanagedHandler;
using SimpleHtmlToPdf.WebApp.Tests.Models;
using System.Diagnostics;

namespace SimpleHtmlToPdf.WebApp.Tests.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger, IConverter converter)
        {
            _logger = logger;
            Converter = converter;
        }

        private IConverter Converter { get; }
        private readonly ILogger<HomeController> _logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

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