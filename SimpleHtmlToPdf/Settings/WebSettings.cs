using SimpleHtmlToPdf.Attributes;
using SimpleHtmlToPdf.Interfaces;

namespace SimpleHtmlToPdf.Settings
{
    /// <summary>
    /// Web settings
    /// </summary>
    /// <seealso cref="ISettings"/>
    public class WebSettings : ISettings
    {
        /// <summary>
        /// Should we print the background. Default = true
        /// </summary>
        /// <value>The background.</value>
        [WkHtml("web.background")]
        public bool? Background { get; set; }

        /// <summary>
        /// What encoding should we guess content is using if they do not specify it properly.
        /// Default = ""
        /// </summary>
        /// <value>The default encoding.</value>
        [WkHtml("web.defaultEncoding")]
        public string DefaultEncoding { get; set; }

        /// <summary>
        /// Should we enable intelligent shrinkng to fit more content on one page. Has no effect for
        /// wkhtmltoimage. Default = true
        /// </summary>
        /// <value>The enable intelligent shrinking.</value>
        [WkHtml("web.enableIntelligentShrinking")]
        public bool? EnableIntelligentShrinking { get; set; }

        /// <summary>
        /// Should we enable javascript. Default = true
        /// </summary>
        /// <value>The enable javascript.</value>
        [WkHtml("web.enableJavascript")]
        public bool? EnableJavascript { get; set; }

        /// <summary>
        /// Should we enable NS plugins. Enabling this will have limited success. Default = false
        /// </summary>
        /// <value>The enable plugins.</value>
        [WkHtml("web.enablePlugins")]
        public bool? EnablePlugins { get; set; }

        /// <summary>
        /// Should we load images. Default = true
        /// </summary>
        /// <value>The load images.</value>
        [WkHtml("web.loadImages")]
        public bool? LoadImages { get; set; }

        /// <summary>
        /// The minimum font size allowed. Default = -1
        /// </summary>
        /// <value>The minimum size of the font.</value>
        [WkHtml("web.minimumFontSize")]
        public int? MinimumFontSize { get; set; }

        /// <summary>
        /// Should the content be printed using the print media type instead of the screen media
        /// type. Default = false
        /// </summary>
        /// <value>The type of the print media.</value>
        [WkHtml("web.printMediaType")]
        public bool? PrintMediaType { get; set; }

        /// <summary>
        /// Url or path to a user specified style sheet. Default = ""
        /// </summary>
        /// <value>The user style sheet.</value>
        [WkHtml("web.userStyleSheet")]
        public string UserStyleSheet { get; set; }
    }
}