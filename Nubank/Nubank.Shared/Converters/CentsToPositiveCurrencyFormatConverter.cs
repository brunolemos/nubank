using System;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class CentsToPositiveCurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object showSymbol, string language)
        {
            var positiveValue = Math.Abs(double.Parse(value.ToString()));
            return new CentsToCurrencyFormatConverter().Convert(positiveValue, targetType, showSymbol, language);
        }

        public object ConvertBack(object value, Type targetType, object showSymbol, string language)
        {
            return new CentsToCurrencyFormatConverter().ConvertBack(value, targetType, showSymbol, language);
        }
    }
}
