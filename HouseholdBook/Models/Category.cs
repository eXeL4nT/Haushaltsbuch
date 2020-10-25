using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseholdBook.Models
{
    class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
