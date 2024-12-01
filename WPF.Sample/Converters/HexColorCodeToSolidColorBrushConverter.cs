using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPF.Sample.Converters
{
    public class HexColorCodeToSolidColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is string hexColorCode)
                {
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColorCode));
                }
            }
            catch (Exception) { }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
