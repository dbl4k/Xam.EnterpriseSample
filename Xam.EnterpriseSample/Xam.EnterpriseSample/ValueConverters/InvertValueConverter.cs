using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xam.EnterpriseSample.ValueConverters
{
   // [ValueConversion(typeof(bool), typeof(bool))]
    class InvertValueConverter : IValueConverter
    {
        private const string M_BOOLEAN_ONLY = "Converter only designated for Boolean values.";

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException(M_BOOLEAN_ONLY);

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
