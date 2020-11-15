using System.Globalization;
using System.Windows.Controls;

namespace HouseholdBook.WPF.Rules
{
    class BookingAmountValidationRule : ValidationRule
    {
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 999999;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string amount = (string)value;

            if (!double.TryParse(amount, out double userInput))
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

            return new ValidationResult(true, null);
        }
    }
}
