using SimpleHtmlToPdf.Interfaces;
using SimpleHtmlToPdf.Settings;
using System.Collections.Generic;

namespace SimpleHtmlToPdf
{
    /// <summary>
    /// Html to Pdf document
    /// </summary>
    /// <seealso cref="IDocument"/>
    public class HtmlToPdfDocument : IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlToPdfDocument"/> class.
        /// </summary>
        public HtmlToPdfDocument()
        {
            Objects = new List<ObjectSettings>();
        }

        /// <summary>
        /// Gets or sets the global settings.
        /// </summary>
        /// <value>The global settings.</value>
        public GlobalSettings GlobalSettings { get; set; } = new GlobalSettings();

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        public List<ObjectSettings> Objects { get; }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <returns>The objects in a document.</returns>
        public IEnumerable<IObject> GetObjects()
        {
            return Objects.ToArray();
        }
    }
}