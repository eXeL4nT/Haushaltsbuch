using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdBook.EntityFramework.Models
{
    public class Booking : BaseModel
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }

        public Category Category { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
