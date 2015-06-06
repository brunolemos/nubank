using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class CentsToCurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var v = double.Parse(value.ToString()) / 100;
            return string.Format("{0:C}", v);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
