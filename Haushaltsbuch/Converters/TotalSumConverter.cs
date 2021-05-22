using Haushaltsbuch.EntityFramework;
using Haushaltsbuch.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Haushaltsbuch.Converters
{
    public class TotalSumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IEnumerable<object> bookings)) return "0,00€";

            double sum = 0;

            foreach (BookingPanelViewModel booking in bookings)
            {
                if (booking.Booking.BookingOption == (int)BookingOption.Expenditure)
                {
                    sum -= booking.Booking.Amount;
                }
                else
                {
                    sum += booking.Booking.Amount;
                }
            }

            return sum.ToString("c");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
