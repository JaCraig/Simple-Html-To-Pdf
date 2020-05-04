namespace SimpleHtmlToPdf.Interfaces
{
    /// <summary>
    /// Object interface
    /// </summary>
    public interface IObject : ISettings
    {
        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns>The content</returns>
        byte[] GetContent();
    }
}