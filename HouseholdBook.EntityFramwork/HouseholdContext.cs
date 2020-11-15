using HouseholdBook.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdBook
{
    class HouseholdContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<RecurringBooking> RecurringBookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("Server = fboehme; Database = household_database; Uid = user; Pwd = password;");
        }
    }
}
