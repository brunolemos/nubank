using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class NumberGreaterThanNToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double a, b;
            double.TryParse(value.ToString(), out a);
            double.TryParse(parameter.ToString(), out b);

            return a > b ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
