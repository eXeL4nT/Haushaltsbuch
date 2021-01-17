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
        private event BookingCallback BookingCallback;

        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel _overviewViewModel;
        private readonly IBookingService _bookingService;

        public DeleteEntryCommand(OverviewViewModel overviewViewModel, IBookingService bookingService, BookingCallback bookingCallback)
        {
            _overviewViewModel = overviewViewModel;
            _bookingService = bookingService;
            BookingCallback = bookingCallback;
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
                await _bookingService.DeleteBooking(_overviewViewModel.SelectedBooking);
                BookingCallback?.Invoke();
            }
            catch (Exception)
            {
                _overviewViewModel.ErrorMessage = "Löschen der Buchungen ist fehlgeschlagen!";
            }
        }
    }
}
