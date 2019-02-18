using System;
using System.Globalization;
using MvvmCross.Converters;

namespace TestMVVMCross.Converters
{
    public class TwoWayTestConverter : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value * value).ToString();
        }

        protected override double ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue;
            double.TryParse(value, out doubleValue);
            return Math.Sqrt(doubleValue);
        }
    }
}
