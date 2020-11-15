using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseholdBook.Domain.Models
{
    public class BankAccount : BaseModel
    {
        public string Name { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
