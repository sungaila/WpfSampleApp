﻿using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StarWarsClient.Converters
{
    public class BoolToBoolReversedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolean)
                return DependencyProperty.UnsetValue;

            return !boolean;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static BoolToBoolReversedConverter Instance { get; } = new();
    }
}