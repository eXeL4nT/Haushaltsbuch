using Haushaltsbuch.EntityFramework;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Haushaltsbuch.Converters
{
    public class AmountColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] is double amount) && (values[1] is int bookingOption))
            {
                if (bookingOption == (int)BookingOption.Expenditure)
                {
                    return Brushes.Red;
                }
                else
                {
                    return Brushes.Green;
                }
            }

            return Brushes.Black;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
