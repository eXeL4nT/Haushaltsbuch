using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.EntityFramework
{
    public class HouseholdDbContextFactory : IDesignTimeDbContextFactory<HouseholdDbContext>
    {
        public HouseholdDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<HouseholdDbContext>();
            options.UseMySQL("Server = fboehme; Database = household_database; Uid = user; Pwd = password;");

            return new HouseholdDbContext(options.Options);
        }
    }
}
