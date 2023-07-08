using Microsoft.AspNetCore.Mvc;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.Settings;
using SimpleHtmlToPdf.Settings.Enums;
using SimpleHtmlToPdf.UnmanagedHandler;

namespace SimpleHtmlToPdf.WebApp.net6.Controllers
{
    /// <summary>
    /// The controller used to generate PDFs.
    /// </summary>
    /// <seealso cref="Controller"/>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="converter">The converter.</param>
        public HomeController(IConverter converter)
        {
            Converter = converter;
        }

        /// <summary>
        /// The converter instance to use for converting HTML to PDF.
        /// </summary>
        /// <value>The converter instance to use for converting HTML to PDF.</value>
        private IConverter Converter { get; }

        /// <summary>
        /// Our PDF generation endpoint
        /// </summary>
        /// <returns>The PDF file</returns>
        public IActionResult TestPDF()
        {
            // Define the HTML-to-PDF request input
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    // Color mode of the output file
                    ColorMode = ColorMode.Color,
                    // Orientation of the output file
                    Orientation = Orientation.Landscape,
                    // Paper size of the output file
                    PaperSize = PaperKind.A4Plus,
                },
                Objects = {
                    new ObjectSettings()
                    {
                        // HTML content to convert
                        HtmlContent = "<html><body>Test</body></html>",
                        // The default encoding used.
                        WebSettings = { DefaultEncoding = "utf-8" },
                    },
                }
            };

            // Convert our HTML document to a PDF document
            var pdf = Converter.Convert(doc);

            // Send the PDF file to the browser
            return File(pdf, "application/pdf", "Test.pdf");
        }
    }
}