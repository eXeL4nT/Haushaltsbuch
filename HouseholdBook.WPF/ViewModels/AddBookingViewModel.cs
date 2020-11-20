using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class AddBookingViewModel : ViewModelBase
    {
        public ICommand AddBookingCommand { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public Category Category { get; set; }
        public BankAccount BankAccount { get; set; }

        public AddBookingViewModel(IDataService<Booking> bookingService)
        {
            AddBookingCommand = new AddBookingCommand(this, bookingService);
        }
    }
}
