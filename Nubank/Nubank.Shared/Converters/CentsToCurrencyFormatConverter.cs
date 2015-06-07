using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class CentsToCurrencyFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object showSymbol, string language)
        {
            var v = double.Parse(value.ToString()) / 100;

            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat;
            nfi = (NumberFormatInfo)nfi.Clone();

            bool _showSymbol = true;
            if(showSymbol != null && !string.IsNullOrEmpty(showSymbol.ToString())) Boolean.TryParse(showSymbol.ToString(), out _showSymbol);

            if(!_showSymbol) nfi.CurrencySymbol = "";
            return string.Format(nfi, "{0:c}", v);
        }

        public object ConvertBack(object value, Type targetType, object showSymbol, string language)
        {
            throw new NotImplementedException();
        }
    }
}
