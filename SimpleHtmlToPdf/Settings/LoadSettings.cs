using SimpleHtmlToPdf.Attributes;
using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.Settings.Enums;
using System.Collections.Generic;

namespace SimpleHtmlToPdf.Settings
{
    /// <summary>
    /// Load settings
    /// </summary>
    /// <seealso cref="ISettings"/>
    public class LoadSettings : ISettings
    {
        /// <summary>
        /// Disallow local and piped files to access other local files. Default = false
        /// </summary>
        /// <value>The block local file access.</value>
        [WkHtml("load.blockLocalFileAccess")]
        public bool? BlockLocalFileAccess { get; set; }

        /// <summary>
        /// Cookies used when requesting page. Default = empty
        /// </summary>
        /// <value>The cookies.</value>
        [WkHtml("load.cookies")]
        public Dictionary<string, string> Cookies { get; set; }

        /// <summary>
        /// Custom headers used when requesting page. Defaulty = empty
        /// </summary>
        /// <value>The custom headers.</value>
        [WkHtml("load.customHeaders")]
        public Dictionary<string, string> CustomHeaders { get; set; }

        /// <summary>
        /// Forward javascript warnings and errors to the warning callback. Default = false
        /// </summary>
        /// <value>The debug javascript.</value>
        [WkHtml("load.debugJavascript")]
        public bool? DebugJavascript { get; set; }

        /// <summary>
        /// The mount of time in milliseconds to wait after a page has done loading until it is
        /// actually printed. E.g. "1200". We will wait this amount of time or until, javascript
        /// calls window.print(). Default = 200
        /// </summary>
        /// <value>The js delay.</value>
        [WkHtml("load.jsdelay")]
        public int? JSDelay { get; set; }

        /// <summary>
        /// How should we handle obejcts that fail to load. Default = Abort
        /// </summary>
        /// <value>The load error handling.</value>
        [WkHtml("load.loadErrorHandling")]
        public ContentErrorHandling? LoadErrorHandling { get; set; }

        /// <summary>
        /// The password to used when logging into a website. Default = ""
        /// </summary>
        [WkHtml("load.password")]
        public string Password { get; set; }

        /// <summary>
        /// String describing what proxy to use when loading the object. Default = ""
        /// </summary>
        /// <value>The proxy.</value>
        [WkHtml("load.proxy")]
        public string Proxy { get; set; }

        /// <summary>
        /// Should the custom headers be sent all elements loaded instead of only the main page.
        /// Default = false
        /// </summary>
        /// <value>The repeat custom headers.</value>
        [WkHtml("load.repeatCustomHeaders")]
        public bool? RepeatCustomHeaders { get; set; }

        /// <summary>
        /// Stop slow running javascript. Default = true
        /// </summary>
        /// <value>The stop slow script.</value>
        [WkHtml("load.stopSlowScript")]
        public bool? StopSlowScript { get; set; }

        /// <summary>
        /// The user name to use when loging into a website. Default = ""
        /// </summary>
        /// <value>The username.</value>
        [WkHtml("load.username")]
        public string Username { get; set; }

        /// <summary>
        /// How much should we zoom in on the content. Default = 1.0
        /// </summary>
        /// <value>The zoom factor.</value>
        [WkHtml("load.zoomFactor")]
        public double? ZoomFactor { get; set; }
    }
}