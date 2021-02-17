﻿using HouseholdBook.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseholdBook.EntityFramework
{
    public class HouseholdDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        public HouseholdDbContext(DbContextOptions<HouseholdDbContext> options) : base(options) { }
    }
}
