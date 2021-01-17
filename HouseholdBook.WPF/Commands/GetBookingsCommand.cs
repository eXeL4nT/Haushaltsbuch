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

        public async void Execute(object parameter)
        {
            overviewViewModel.ErrorMessage = string.Empty;

            try
            {
                overviewViewModel.Bookings = await bookingService.GetBookings();
            }
            catch (Exception e)
            {
                overviewViewModel.ErrorMessage = $"Es ist ein Fehler beim Abrufen der Daten aufgetreten. {e.Message}";
            }
        }
    }
}
