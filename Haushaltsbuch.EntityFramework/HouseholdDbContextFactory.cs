using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haushaltsbuch.EntityFramework
{
    public class HouseholdDbContextFactory : IDesignTimeDbContextFactory<HouseholdDbContext>
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public HouseholdDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public HouseholdDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<HouseholdDbContext>();

            _configureDbContext(options);

            return new HouseholdDbContext(options.Options);
        }
    }
}
