using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haushaltsbuch.EntityFramework.Models
{
    public class Booking : BaseModel
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int BookingOption { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
