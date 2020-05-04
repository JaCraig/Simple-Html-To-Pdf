using SimpleHtmlToPdf.Interfaces;
using System;

namespace SimpleHtmlToPdf.Events
{
    /// <summary>
    /// Finished args
    /// </summary>
    /// <seealso cref="System.EventArgs"/>
    public class FinishedArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        public IDocument Document { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FinishedArgs"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }
    }
}