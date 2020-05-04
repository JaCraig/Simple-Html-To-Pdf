using SimpleHtmlToPdf.Attributes;
using SimpleHtmlToPdf.Interfaces;
using System;
using System.Text;

namespace SimpleHtmlToPdf.Settings
{
    /// <summary>
    /// Object settings
    /// </summary>
    /// <seealso cref="IObject"/>
    public class ObjectSettings : IObject
    {
        /// <summary>
        /// Gets or sets the footer settings.
        /// </summary>
        /// <value>The footer settings.</value>
        public FooterSettings FooterSettings { get; set; } = new FooterSettings();

        /// <summary>
        /// Gets or sets the header settings.
        /// </summary>
        /// <value>The header settings.</value>
        public HeaderSettings HeaderSettings { get; set; } = new HeaderSettings();

        /// <summary>
        /// Gets or sets the content of the HTML.
        /// </summary>
        /// <value>The content of the HTML.</value>
        public string HtmlContent { get; set; }

        /// <summary>
        /// Should the sections from this document be included in the outline and table of content.
        /// Default = false
        /// </summary>
        /// <value>The include in outline.</value>
        [WkHtml("includeInOutline")]
        public bool? IncludeInOutline { get; set; }

        /// <summary>
        /// Gets or sets the load settings.
        /// </summary>
        /// <value>The load settings.</value>
        public LoadSettings LoadSettings { get; set; } = new LoadSettings();

        /// <summary>
        /// The URL or path of the web page to convert, if "-" input is read from stdin. Default = ""
        /// </summary>
        /// <value>The page.</value>
        [WkHtml("page")]
        public string Page { get; set; }

        /// <summary>
        /// Should we count the pages of this document, in the counter used for TOC, headers and
        /// footers. Default = false
        /// </summary>
        /// <value>The pages count.</value>
        [WkHtml("pagesCount")]
        public bool? PagesCount { get; set; }

        /// <summary>
        /// Should we turn HTML forms into PDF forms. Default = false
        /// </summary>
        /// <value>The produce forms.</value>
        [WkHtml("produceForms")]
        public bool? ProduceForms { get; set; }

        /// <summary>
        /// Should external links in the HTML document be converted into external pdf links. Default
        /// = true
        /// </summary>
        /// <value>The use external links.</value>
        [WkHtml("useExternalLinks")]
        public bool? UseExternalLinks { get; set; }

        /// <summary>
        /// Should internal links in the HTML document be converted into pdf references. Default = true
        /// </summary>
        /// <value>The use local links.</value>
        [WkHtml("useLocalLinks")]
        public bool? UseLocalLinks { get; set; }

        /// <summary>
        /// Gets or sets the web settings.
        /// </summary>
        /// <value>The web settings.</value>
        public WebSettings WebSettings { get; set; } = new WebSettings();

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns>The content</returns>
        public byte[] GetContent()
        {
            return HtmlContent is null
                ? Array.Empty<byte>()
                : Encoding.UTF8.GetBytes(HtmlContent);
        }
    }
}