using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.EntityFramework
{
    public class HouseholdDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> configureDbContext;

        public HouseholdDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            this.configureDbContext = configureDbContext;
        }

        public HouseholdDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<HouseholdDbContext> options = new DbContextOptionsBuilder<HouseholdDbContext>();

            configureDbContext(options);

            return new HouseholdDbContext(options.Options);
        }
    }
}
