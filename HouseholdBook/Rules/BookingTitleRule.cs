using System;
using System.Globalization;
using System.Windows.Controls;

namespace HouseholdBook.Rules
{
    class BookingTitleRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty((string) value))
            {
                return new ValidationResult(false, "Bitte etwas eingeben.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
