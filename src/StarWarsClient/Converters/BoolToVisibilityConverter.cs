using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StarWarsClient.Converters
{
    /// <summary>
    /// Converts a <see langword="bool"/> into a <see cref="Visibility"/>.
    /// The conversion can be reverted by using <see langword="true"/> for the converter parameter.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not bool boolean)
                return DependencyProperty.UnsetValue;

            if (bool.TryParse(parameter as string, out var reversed) && reversed)
            {
                return boolean ? Visibility.Collapsed : Visibility.Visible;
            }

            return boolean ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static BoolToVisibilityConverter Instance { get; } = new();
    }
}