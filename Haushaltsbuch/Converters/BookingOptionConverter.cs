using System;
using System.Globalization;
using System.Windows.Data;
using Haushaltsbuch.EntityFramework;

namespace Haushaltsbuch.Converters
{
    public class BookingOptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parseSuccess = Enum.TryParse((string)parameter, true, out BookingOption paramBookingOption);
            
            if (value is int bookingOptionInt)
            {
                return parseSuccess && bookingOptionInt == (int) paramBookingOption;
            }
            else if (value is BookingOption bookingOption)
            {
                return parseSuccess && bookingOption == paramBookingOption;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool b && b)) return null;
            Enum.TryParse((string)parameter, true, out BookingOption paramBookingOption);
            return (int) paramBookingOption;
        }
    }
}
