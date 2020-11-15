using HouseholdBook.Domain.Models;
using HouseholdBook.Domain.Services;
using HouseholdBook.Domain.Services.BookingServices;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Windows;

namespace HouseholdBook.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            IDataService<Booking> bookingService = new BookingDataService(new EntityFramework.HouseholdDbContextFactory());
            IDataService<Category> categoryService = new CategoryDataService(new EntityFramework.HouseholdDbContextFactory());
            IDataService<BankAccount> bankAccountService = new BankAccountDataService(new EntityFramework.HouseholdDbContextFactory());
            IAddIncomeService addIncomeService = new AddIncomeService(bookingService);

            Category category = categoryService.Get("Lebensmittel").Result;
            BankAccount bankAccount = bankAccountService.Get("Girokonto").Result;
            Booking test = new Booking { Title = "aa", Amount = 5, Date = "15.11.2020", Category = category, BankAccount = bankAccount };

            await addIncomeService.AddIncome(test);

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }
}
