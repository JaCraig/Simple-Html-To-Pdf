using SimpleHtmlToPdf.Interfaces;
using System;

namespace SimpleHtmlToPdf.Events
{
    /// <summary>
    /// Error args
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class ErrorArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public IDocument? Document { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string? Message { get; set; }
    }
}