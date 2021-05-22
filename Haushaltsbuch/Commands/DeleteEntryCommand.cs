using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class DeleteEntryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel _overviewViewModel;
        private readonly BookingPanelViewModel _bookingPanelViewModel;
        private readonly IBookingService _bookingService;

        public DeleteEntryCommand(OverviewViewModel overviewViewModel, BookingPanelViewModel bookingPanelViewModel, IBookingService bookingService)
        {
            _overviewViewModel = overviewViewModel;
            _bookingPanelViewModel = bookingPanelViewModel;
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
                var booking = await _bookingService.DeleteBooking(_bookingPanelViewModel.Booking);
                //_overviewViewModel.Bookings.Remove(_bookingPanelViewModel);
            }
            catch (Exception)
            {
                _overviewViewModel.ErrorMessage = "Löschen der Buchungen ist fehlgeschlagen!";
            }
        }
    }
}
