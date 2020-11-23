using HouseholdBook.EntityFramework;
using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.ViewModels.Factories;
using HouseholdBook.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HouseholdBook.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("sqlite");
                    Action<DbContextOptionsBuilder> configureDbContext = d => d.UseSqlite(connectionString);
                    services.AddDbContext<HouseholdDbContext>(configureDbContext);
                    services.AddSingleton(new HouseholdDbContextFactory(configureDbContext));

                    services.AddSingleton<BookingDataService>();
                    services.AddSingleton<IDataService<Category>, GenericDataService<Category>>();
                    services.AddSingleton<IDataService<BankAccount>, GenericDataService<BankAccount>>();
                    services.AddSingleton<IBookingService, BookingService>();
                    services.AddSingleton<ICategoryService, CategoryService>();
                    services.AddSingleton<IBankAccountService, BankAccountService>();

                    services.AddSingleton<IHouseholdViewModelFactory, HouseholdViewModelFactory>();
                    services.AddSingleton<OverviewViewModel>();
                    services.AddSingleton<AddBookingViewModel>();
                    services.AddSingleton<EditBookingViewModel>();

                    services.AddScoped<MainViewModel>();

                    services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            host.Start();
            
            HouseholdDbContextFactory contextFactory = host.Services.GetRequiredService<HouseholdDbContextFactory>();
            using (HouseholdDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }
           
            Window window = host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync();
            host.Dispose();

            base.OnExit(e);
        }
    }
}
