using HouseholdBook.EntityFramework;
using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.ViewModels.Factories;
using HouseholdBook.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace HouseholdBook.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<HouseholdDbContextFactory>();
            services.AddSingleton<IDataService<Booking>, BookingDataService>();

            services.AddSingleton<IHouseholdViewModelFactory, HouseholdViewModelFactory>();
            services.AddSingleton<OverviewViewModel>();
            services.AddSingleton<AddBookingViewModel>();
            services.AddSingleton<EditBookingViewModel>();

            services.AddScoped<MainViewModel>();

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            
            return services.BuildServiceProvider();
        }
    }
}
