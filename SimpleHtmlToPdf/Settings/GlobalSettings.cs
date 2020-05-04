using SimpleHtmlToPdf.Attributes;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.Settings.Enums;

namespace SimpleHtmlToPdf.Settings
{
    /// <summary>
    /// Global settings
    /// </summary>
    /// <seealso cref="ISettings"/>
    public class GlobalSettings : ISettings
    {
        /// <summary>
        /// Should the copies be collated. Default = true
        /// </summary>
        /// <value>The collate.</value>
        [WkHtml("collate")]
        public bool? Collate { get; set; }

        /// <summary>
        /// Should the output be printed in color or gray scale, must be either "Color" or
        /// "Grayscale". Default = "color"
        /// </summary>
        /// <value>The color mode.</value>
        [WkHtml("colorMode")]
        public ColorMode? ColorMode { get; set; }

        /// <summary>
        /// Path of file used to load and store cookies. Default = ""
        /// </summary>
        /// <value>The cookie jar.</value>
        [WkHtml("load.cookieJar")]
        public string CookieJar { get; set; }

        /// <summary>
        /// How many copies should we print. Default = 1
        /// </summary>
        /// <value>The copies.</value>
        [WkHtml("copies")]
        public int? Copies { get; set; }

        /// <summary>
        /// The title of the PDF document. Default = ""
        /// </summary>
        /// <value>The document title.</value>
        [WkHtml("documentTitle")]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// What dpi should we use when printing. Default = 96
        /// </summary>
        /// <value>The dpi.</value>
        [WkHtml("dpi")]
        public int? DPI { get; set; }

        /// <summary>
        /// If not set to the empty string a XML representation of the outline is dumped to this
        /// file. Default = ""
        /// </summary>
        /// <value>The dump outline.</value>
        [WkHtml("dumpOutline")]
        public string DumpOutline { get; set; }

        /// <summary>
        /// The maximal DPI to use for images in the pdf document. Default = 600
        /// </summary>
        /// <value>The image dpi.</value>
        [WkHtml("imageDPI")]
        public int? ImageDPI { get; set; }

        /// <summary>
        /// The jpeg compression factor to use when producing the pdf document. Default = 94
        /// </summary>
        /// <value>The image quality.</value>
        [WkHtml("imageQuality")]
        public int? ImageQuality { get; set; }

        /// <summary>
        /// Gets or sets the margins.
        /// </summary>
        /// <value>The margins.</value>
        public MarginSettings Margins { get; set; } = new MarginSettings();

        /// <summary>
        /// The orientation of the output document, must be either "Landscape" or "Portrait".
        /// Default = "portrait"
        /// </summary>
        /// <value>The orientation.</value>
        [WkHtml("orientation")]
        public Orientation? Orientation { get; set; }

        /// <summary>
        /// The path of the output file, if "-" output is sent to stdout, if empty the output is
        /// stored in a buffer. Default = ""
        /// </summary>
        /// <value>The out.</value>
        [WkHtml("out")]
        public string Out { get; set; }

        /// <summary>
        /// Should a outline (table of content in the sidebar) be generated and put into the PDF.
        /// Default = true
        /// </summary>
        /// <value>The outline.</value>
        [WkHtml("outline")]
        public bool? Outline { get; set; }

        /// <summary>
        /// The maximal depth of the outline. Default = 4
        /// </summary>
        /// <value>The outline depth.</value>
        [WkHtml("outlineDepth")]
        public int? OutlineDepth { get; set; }

        /// <summary>
        /// A number that is added to all page numbers when printing headers, footers and table of
        /// content. Default = 0
        /// </summary>
        /// <value>The page offset.</value>
        [WkHtml("pageOffset")]
        public int? PageOffset { get; set; }

        /// <summary>
        /// Size of output paper
        /// </summary>
        /// <value>The size of the paper.</value>
        public PechkinPaperSize PaperSize { get; set; }

        /// <summary>
        /// Should we use loss less compression when creating the pdf file. Default = true
        /// </summary>
        /// <value>The use compression.</value>
        [WkHtml("useCompression")]
        public bool? UseCompression { get; set; }

        /// <summary>
        /// Set viewport size. Not supported in wkhtmltopdf API since v0.12.2.4
        /// </summary>
        /// <value>The size of the viewport.</value>
        [WkHtml("viewportSize")]
        public string ViewportSize { get; set; }

        /// <summary>
        /// Size of the bottom margin
        /// </summary>
        /// <value>The margin bottom.</value>
        [WkHtml("margin.bottom")]
        private string MarginBottom
        {
            get
            {
                return Margins.GetMarginValue(Margins.Bottom);
            }
        }

        /// <summary>
        /// Size of the left margin
        /// </summary>
        /// <value>The margin left.</value>
        [WkHtml("margin.left")]
        private string MarginLeft
        {
            get
            {
                return Margins.GetMarginValue(Margins.Left);
            }
        }

        /// <summary>
        /// Size of the right margin
        /// </summary>
        /// <value>The margin right.</value>
        [WkHtml("margin.right")]
        private string MarginRight
        {
            get
            {
                return Margins.GetMarginValue(Margins.Right);
            }
        }

        /// <summary>
        /// Size of the top margin
        /// </summary>
        /// <value>The margin top.</value>
        [WkHtml("margin.top")]
        private string MarginTop
        {
            get
            {
                return Margins.GetMarginValue(Margins.Top);
            }
        }

        /// <summary>
        /// The height of the output document
        /// </summary>
        /// <value>The height of the paper.</value>
        [WkHtml("size.height")]
        private string PaperHeight
        {
            get
            {
                return PaperSize == null ? null : PaperSize.Height;
            }
        }

        /// <summary>
        /// The width of the output document
        /// </summary>
        /// <value>The width of the paper.</value>
        [WkHtml("size.width")]
        private string PaperWidth
        {
            get
            {
                return PaperSize == null ? null : PaperSize.Width;
            }
        }
    }
}