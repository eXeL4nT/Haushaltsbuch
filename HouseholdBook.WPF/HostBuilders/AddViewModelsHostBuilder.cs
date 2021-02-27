using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.ViewModels.Factories;
using HouseholdBook.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilder
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient<OverviewViewModel>();
                services.AddTransient<AddEntryViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<OverviewViewModel>>(services => () => services.GetRequiredService<OverviewViewModel>());
                services.AddSingleton<CreateViewModel<AddEntryViewModel>>(services => () => services.GetRequiredService<AddEntryViewModel>());
                services.AddSingleton<CreateViewModel<MainViewModel>>(services => () => services.GetRequiredService<MainViewModel>());

                services.AddSingleton<IHouseholdViewModelFactory, HouseholdViewModelFactory>();
            });

            return host;
        }
    }
}
