using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class GetBookingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel overviewViewModel;
        private readonly IBookingService bookingService;

        public GetBookingsCommand(OverviewViewModel overviewViewModel, IBookingService bookingService)
        {
            this.overviewViewModel = overviewViewModel;
            this.bookingService = bookingService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            overviewViewModel.ErrorMessage = string.Empty;

            try
            {
                overviewViewModel.Bookings = bookingService.GetBookings().Result;
            }
            catch (Exception)
            {
                overviewViewModel.ErrorMessage = "Abrufen der Buchungen ist fehlgeschlagen!";
            }
        }
    }
}
