using System;

namespace SimpleHtmlToPdf.Attributes
{
    /// <summary>
    /// Wkhtml attribute
    /// </summary>
    /// <seealso cref="System.Attribute"/>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class WkHtmlAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WkHtmlAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public WkHtmlAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }
    }
}