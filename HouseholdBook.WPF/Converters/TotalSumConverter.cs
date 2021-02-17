﻿using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace HouseholdBook.WPF.Converters
{
    public class TotalSumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IEnumerable<object> bookings)) return "0,00€";

            double sum = 0;

            foreach (var booking in bookings)
            {
                sum += ((Booking)booking).Amount;
            }

            return sum.ToString("c");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
