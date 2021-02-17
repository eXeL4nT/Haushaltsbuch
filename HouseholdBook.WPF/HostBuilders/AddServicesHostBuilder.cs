using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.HostBuilders
{
    public static class AddServicesHostBuilder
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<BookingDataService>();
                services.AddSingleton<CategoryDataService>();
                services.AddSingleton<IDataService<BankAccount>, GenericDataService<BankAccount>>();
                services.AddSingleton<IBookingService, BookingService>();
                services.AddSingleton<ICategoryService, CategoryService>();
                services.AddSingleton<IBankAccountService, BankAccountService>();
            });

            return host;
        }
    }
}
