using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    class AddBookingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly OverviewViewModel _overviewViewModel;
        private readonly IBookingService _bookingService;
        private readonly IDialogService _dialogService;

        public AddBookingCommand(AddEntryViewModel addBookingViewModel, OverviewViewModel overviewViewModel, IBookingService bookingService, IDialogService dialogService)
        {
            _addEntryViewModel = addBookingViewModel;
            _overviewViewModel = overviewViewModel;
            _bookingService = bookingService;
            _dialogService = dialogService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            _addEntryViewModel.ErrorMessage = string.Empty;

            try
            {   
                var booking = await _bookingService.AddBooking(_addEntryViewModel.Title, _addEntryViewModel.Amount, _addEntryViewModel.Date, _addEntryViewModel.BookingOption, _addEntryViewModel.SelectedCategory, _addEntryViewModel.SelectedBankAccount);
                //_overviewViewModel.Bookings.Add(new BookingPanelViewModel(_overviewViewModel, booking, _bookingService, _dialogService));

                _overviewViewModel.GetYears();

                Cleanup();
            }
            catch (Exception e)
            {
                _addEntryViewModel.ErrorMessage = $"Es ist ein Fehler aufgetreten. {e.Message}";
            }
        }

        public void Cleanup()
        {
            _addEntryViewModel.Title = null;
            _addEntryViewModel.Amount = 0;
            _addEntryViewModel.Date = DateTime.Now;
            //_addEntryViewModel.BookingOption = 0;
            _addEntryViewModel.SelectedCategory = null;
        }
    }
}
