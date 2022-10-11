using SimpleHtmlToPdf.Settings.Enums;
using System.Globalization;

namespace SimpleHtmlToPdf.Settings
{
    /// <summary>
    /// Margin settings
    /// </summary>
    public class MarginSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MarginSettings"/> class.
        /// </summary>
        public MarginSettings()
        {
            Unit = Unit.Millimeters;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarginSettings"/> class.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <param name="right">The right.</param>
        /// <param name="bottom">The bottom.</param>
        /// <param name="left">The left.</param>
        public MarginSettings(double top, double right, double bottom, double left) : this()
        {
            Top = top;

            Bottom = bottom;

            Left = left;

            Right = right;
        }

        /// <summary>
        /// Gets or sets the bottom.
        /// </summary>
        /// <value>The bottom.</value>
        public double? Bottom { get; set; }

        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        /// <value>The left.</value>
        public double? Left { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        /// <value>The right.</value>
        public double? Right { get; set; }

        /// <summary>
        /// Gets or sets the top.
        /// </summary>
        /// <value>The top.</value>
        public double? Top { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public Unit Unit { get; set; }

        /// <summary>
        /// Gets the margin value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string? GetMarginValue(double? value)
        {
            return !value.HasValue
                ? null
                : value.Value.ToString("0.##", CultureInfo.InvariantCulture) + (Unit switch
                {
                    Unit.Inches => "in",
                    Unit.Millimeters => "mm",
                    Unit.Centimeters => "cm",
                    _ => "in",
                });
        }
    }
}