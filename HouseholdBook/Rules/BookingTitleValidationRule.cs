using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace HouseholdBook.Rules
{
    class BookingTitleValidationRule : ValidationRule
    {
        public int Length { get; set; } = 3;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string title = (string) value;

            if (title.Length < Length)
            {
                return new ValidationResult(false, "Bitte einen Titel mit mindestens " + Length + " Zeichen angeben.");
            }

            return new ValidationResult(true, null);
        }
    }
}
