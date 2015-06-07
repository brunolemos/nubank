using Nubank.Models;
using System;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class BillItemToInstallmentStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var billItem = (BillItem)value;
            if (billItem == null) return "";

            return billItem.Charges > 1 ? string.Format("{0}/{1} - ", billItem.Index + 1, billItem.Charges) : "";
        }

        public object ConvertBack(object value, Type targetType, object operation, string language)
        {
            throw new NotImplementedException();
        }
    }
}
