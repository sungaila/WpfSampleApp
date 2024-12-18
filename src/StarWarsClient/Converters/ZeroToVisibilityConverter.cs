using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace StarWarsClient.Converters
{
    /// <summary>
    /// Converts an <see langword="int"/> into a <see cref="Visibility"/>.
    /// The conversion can be reverted by using <see langword="true"/> for the converter parameter.
    /// </summary>
    public class ZeroToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int count)
                return DependencyProperty.UnsetValue;

            if (bool.TryParse(parameter as string, out var reversed) && reversed)
            {
                return count > 0 ? Visibility.Collapsed : Visibility.Visible;
            }

            return count <= 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public static ZeroToVisibilityConverter Instance { get; } = new();
    }
}