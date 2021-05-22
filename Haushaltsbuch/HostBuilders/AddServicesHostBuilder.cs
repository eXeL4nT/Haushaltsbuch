using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Haushaltsbuch.HostBuilders
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

                services.AddSingleton<IDialogService, DialogService>();
            });

            return host;
        }
    }
}
