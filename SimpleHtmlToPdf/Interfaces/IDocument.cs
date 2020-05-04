using System.Collections.Generic;

namespace SimpleHtmlToPdf.Interfaces
{
    /// <summary>
    /// Document interface
    /// </summary>
    public interface IDocument : ISettings
    {
        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <returns>The objects in a document.</returns>
        IEnumerable<IObject> GetObjects();
    }
}