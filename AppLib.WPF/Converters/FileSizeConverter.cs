﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace AppLib.WPF.Converters
{
    /// <summary>
    /// Converts a long value to a human readable File size
    /// </summary>
    public class FileSizeConverter : ConverterBase<FileSizeConverter>, IValueConverter
    {
        /// <summary>
        /// Calculate a file size in bytes to a human readable size
        /// </summary>
        /// <param name="value">long input value</param>
        /// <returns>Human readable file size</returns>
        public static string Calculate(long value)
        {
            double val = System.Convert.ToDouble(value);
            string unit = "Byte";
            if (val > 1099511627776D)
            {
                val /= 1099511627776D;
                unit = "TiB";
            }
            else if (val > 1073741824D)
            {
                val /= 1073741824D;
                unit = "GiB";
            }
            else if (val > 1048576D)
            {
                val /= 1048576D;
                unit = "MiB";
            }
            else if (val > 1024D)
            {
                val /= 1024D;
                unit = "kiB";
            }
            return string.Format("{0:0.###} {1}", val, unit);
        }

        /// <summary>
        /// Converts a long value to a human readable File size
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>string, file size as a readable file size</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ip = System.Convert.ToInt64(value);
            return Calculate(ip);
        }

        /// <summary>
        /// Returns the unmodified input
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>string, file size</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
