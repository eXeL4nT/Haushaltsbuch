using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HouseholdBook.EntityFramework.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
