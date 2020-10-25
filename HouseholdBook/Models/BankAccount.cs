using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseholdBook.Models
{
    class BankAccount
    {
        public int BankAccountId { get; set; }
        [Required]
        public string Name { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
