using Haushaltsbuch.ViewModels;
using Haushaltsbuch.ViewModels.Base;
using Haushaltsbuch.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Haushaltsbuch.HostBuilders
{
    public static class AddViewModelsHostBuilder
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<OverviewViewModel>();
                services.AddTransient<AddEntryViewModel>();
                services.AddScoped<BookingPanelViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<OverviewViewModel>>(services => () => services.GetRequiredService<OverviewViewModel>());
                services.AddSingleton<CreateViewModel<AddEntryViewModel>>(services => () => services.GetRequiredService<AddEntryViewModel>());

                services.AddSingleton<IHouseholdViewModelFactory, HouseholdViewModelFactory>();
            });

            return host;
        }
    }
}
