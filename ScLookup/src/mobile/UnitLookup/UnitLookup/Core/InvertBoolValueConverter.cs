using System;
using System.Globalization;
using Xamarin.Forms;

namespace UnitLookup.Core
{
    public class InvertBoolValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bVal = (bool)value;
            return !bVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
