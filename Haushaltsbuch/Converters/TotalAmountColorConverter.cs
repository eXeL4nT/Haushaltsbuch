using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Haushaltsbuch.Converters
{
    public class TotalAmountColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double amount)
            {
                return GetBrushWithAmount((decimal)amount);
            }
            else
            {
                if (decimal.TryParse((string)value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal totalAmount))
                {
                    return GetBrushWithAmount(totalAmount);
                }

                return Brushes.Black;
            }
        }

        private object GetBrushWithAmount(decimal amount)
        {
            if (amount > 0)
            {
                return Brushes.Green;
            }

            return Brushes.OrangeRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
