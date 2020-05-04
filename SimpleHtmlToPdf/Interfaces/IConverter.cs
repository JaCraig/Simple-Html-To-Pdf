namespace SimpleHtmlToPdf.Interfaces
{
    /// <summary>
    /// Converter interface
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Converts the specified document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>The document as a PDF byte array.</returns>
        byte[] Convert(IDocument document);
    }
}