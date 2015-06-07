using Nubank.Models;
using System;
using Windows.ApplicationModel;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Nubank.Converters
{
    public sealed class BillItemToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (DesignMode.DesignModeEnabled) return new SolidColorBrush(Color.FromArgb(0xff, 0x8a, 0x8a, 0x8a));

            var defaultBrush = (SolidColorBrush)App.Current.Resources["BillItemDefaultBrush"];
            var receivedPaymentBrush = (SolidColorBrush)App.Current.Resources["BillItemPaymentReceivedForegroundBrush"];

            var billItem = (BillItem)value;
            if (billItem == null) return defaultBrush;

            return billItem.Amount < 0 ? receivedPaymentBrush : defaultBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
