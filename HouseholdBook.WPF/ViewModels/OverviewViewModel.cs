using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        public ICommand GetBookingsCommand { get; set; }
        public List<Booking> Bookings { get; set; }

        public OverviewViewModel(IDataService<Booking> bookingService)
        {
            GetBookingsCommand = new GetBookingsCommand(this, bookingService);
            GetBookingsCommand.Execute(null);
        }
    }
}
