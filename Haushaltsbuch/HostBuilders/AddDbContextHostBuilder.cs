using Haushaltsbuch.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Haushaltsbuch.HostBuilders
{
    public static class AddDbContextHostBuilder
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                services.AddDbContext<HouseholdDbContext>(configureDbContext);
                services.AddSingleton(new HouseholdDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
