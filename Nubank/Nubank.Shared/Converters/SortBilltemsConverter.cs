using Nubank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class SortBilltemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var list = value as List<BillItem>;
            if (list == null|| list.Count <= 1) return value;

            var orderedList = list.OrderByDescending<BillItem, DateTime>(item => item.PostDate).ToList<BillItem>();
            return orderedList;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
