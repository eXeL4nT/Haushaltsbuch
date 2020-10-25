using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace HouseholdBook.Rules
{
    class BookingAmountRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!double.TryParse((string) value, out double userInput))
            {
                return new ValidationResult(false, "Bitte eine Zahl eingeben.");
            }

            if (userInput < Min)
            {
                return new ValidationResult(false, "Die Zahl ist zu niedrig.");
            }

            if (userInput > Max)
            {
                return new ValidationResult(false, "Die Zahl ist zu groß.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
