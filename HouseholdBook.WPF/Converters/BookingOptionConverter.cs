using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using HouseholdBook.EntityFramework;
using HouseholdBook.WPF;

namespace HouseholdBook.WPF.Converters
{
    public class BookingOptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is BookingOption bookingOption)) return false;
            var parseSuccess = Enum.TryParse((string)parameter, true, out BookingOption paramBookingOption);
            return parseSuccess && bookingOption == paramBookingOption;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool b && b)) return null;
            Enum.TryParse((string)parameter, true, out BookingOption paramBookingOption);
            return paramBookingOption;
        }
    }
}
