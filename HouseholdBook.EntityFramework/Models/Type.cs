using System.Collections.Generic;

namespace HouseholdBook.EntityFramework.Models
{
    public class Type : BaseModel
    {
        public string Name { get; private set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
