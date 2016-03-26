﻿using System;
using System.Windows;
using System.Windows.Data;

namespace WPFLib.Converters
{
    /// <summary>
    /// Visibility converter class for ImageButton internals
    /// </summary>
    internal class VisibilityConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
