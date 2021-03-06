﻿using System;
using Windows.UI.Xaml.Data;

namespace Nubank.Converters
{
    public sealed class CustomDateFormatUpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            var format = parameter.ToString();
            if (date == null || string.IsNullOrEmpty(format)) return null;

            return date.ToString(format).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
