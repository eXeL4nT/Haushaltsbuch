using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseholdBook.Models
{
    class RecurringBooking : Booking
    {
        public int Day { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
