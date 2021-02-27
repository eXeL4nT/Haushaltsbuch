using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Services;
using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.Views;
using System;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class GetBookingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel _overviewViewModel;
        private readonly IBookingService _bookingService;

        public GetBookingsCommand(OverviewViewModel overviewViewModel, IBookingService bookingService)
        {
            _overviewViewModel = overviewViewModel;
            _bookingService = bookingService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            _overviewViewModel.ErrorMessage = string.Empty;

            try
            {
                var bookings = await _bookingService.GetBookings();

                foreach (var booking in bookings)
                {
                    _overviewViewModel.Bookings.Add(new BookingPanelViewModel(_overviewViewModel, booking, _bookingService));
                }
            }
            catch (Exception e)
            {
                _overviewViewModel.ErrorMessage = $"Es ist ein Fehler beim Abrufen der Daten aufgetreten. {e.Message}";
            }
        }
    }
}
