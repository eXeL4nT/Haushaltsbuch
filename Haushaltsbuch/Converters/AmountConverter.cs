using Haushaltsbuch.EntityFramework;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Haushaltsbuch.Converters
{
    public class AmountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] is double amount) && (values[1] is int bookingOption))
            {
                if (bookingOption == (int)BookingOption.Expenditure)
                {
                    return (amount * -1).ToString("N2", CultureInfo.CreateSpecificCulture("de-DE"));
                }
                else
                {
                    return amount.ToString("N2", CultureInfo.CreateSpecificCulture("de-DE"));
                }
            }

            return 0.ToString("N2", CultureInfo.CreateSpecificCulture("de-DE"));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
