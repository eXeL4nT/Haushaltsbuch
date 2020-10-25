using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HouseholdBook.Models
{
    class Booking
    {
        public int BookingId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public double Amount { get; set; }

        public BankAccount BankAccount { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
    }
}
