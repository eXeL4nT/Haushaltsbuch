using System.Collections.Generic;

namespace HouseholdBook.Domain.Models
{
    public class Type : BaseModel
    {
        public string Name { get; private set; }

        public List<Booking> Bookings { get; set; }
    }
}
