using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
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
                _overviewViewModel.Bookings.Remove(_bookingPanelViewModel);
            }
            catch (Exception)
            {
                _overviewViewModel.ErrorMessage = "Löschen der Buchungen ist fehlgeschlagen!";
            }
        }
    }
}
