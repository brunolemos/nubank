using Nubank.Models;
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Nubank.Converters
{
    public sealed class BillStateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = (BillState)value;
            
            switch(state)
            {
                case BillState.OVERDUE:
                    return (SolidColorBrush)App.Current.Resources["OverdueBillBrush"];

                case BillState.CLOSED:
                    return (SolidColorBrush)App.Current.Resources["ClosedBillBrush"];

                case BillState.OPEN:
                    return (SolidColorBrush)App.Current.Resources["OpenBillBrush"];

                case BillState.FUTURE:
                    return (SolidColorBrush)App.Current.Resources["FutureBillBrush"];

                default:
                    return new SolidColorBrush(Colors.Gray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
