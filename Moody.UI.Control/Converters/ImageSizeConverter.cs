// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageSizeConverter.cs" company="">
//   
// </copyright>
// <summary>
//   The image size converter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Moody.UI.Control.Converters
{
    /// <summary>
    ///     The image size converter.
    /// </summary>
    internal class ImageSizeConverter : IValueConverter
    {
        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parametr">
        /// The parametr.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parametr, CultureInfo culture)
        {
            var source = (ImageSource)value;
            return new Rect(0, 0, source.Width, source.Height);
        }

        /// <summary>
        /// The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parametr">
        /// The parametr.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parametr, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
