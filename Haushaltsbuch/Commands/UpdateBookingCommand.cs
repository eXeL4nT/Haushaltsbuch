using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class UpdateBookingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly ChangeBookingViewModel _changeBookingViewModel;
        private readonly OverviewViewModel _overviewViewModel;
        private readonly Booking _booking;
        private readonly IBookingService _bookingService;
        private readonly DialogService _dialogService;

        public UpdateBookingCommand(ChangeBookingViewModel changeBookingViewModel, OverviewViewModel overviewViewModel, Booking booking, IBookingService bookingService, DialogService dialogService)
        {
            _changeBookingViewModel = changeBookingViewModel;
            _overviewViewModel = overviewViewModel;
            _booking = booking;
            _bookingService = bookingService;
            _dialogService = dialogService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            _changeBookingViewModel.ErrorMessage = string.Empty;

            try
            {
                var booking = await _bookingService.UpdateBooking(_booking);
                /*
                foreach (var bookingPanel in _overviewViewModel.Bookings)
                {
                    if (bookingPanel.Booking.Id.Equals(booking.Id))
                    {
                        _overviewViewModel.Bookings.Remove(bookingPanel);
                        break;
                    }
                }

                _overviewViewModel.Bookings.Add(new BookingPanelViewModel(_overviewViewModel, booking, _bookingService, _dialogService));
                */

            }
            catch (Exception e)
            {
                _changeBookingViewModel.ErrorMessage = $"Es ist ein Fehler aufgetreten. {e.Message}";
            }
        }
    }
}
