using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    class AddBookingCommand : ICommand
    {
        private event BookingCallback BookingCallback;
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel _addEntryViewModel;
        private readonly IBookingService bookingService;

        public AddBookingCommand(AddEntryViewModel addBookingViewModel, IBookingService bookingService, BookingCallback bookingCallback)
        {
            this._addEntryViewModel = addBookingViewModel;
            this.bookingService = bookingService;
            BookingCallback = bookingCallback;
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
                await bookingService.AddBooking(_addEntryViewModel.Title, _addEntryViewModel.Amount, _addEntryViewModel.Date, _addEntryViewModel.SelectedCategory, _addEntryViewModel.SelectedBankAccount);
                Cleanup();
                BookingCallback?.Invoke();
            }
            catch (Exception e)
            {
                _addEntryViewModel.ErrorMessage = $"Die Buchung konnte nicht hinzugefügt werden. {e.Message}";
            }
        }

        public void Cleanup()
        {
            _addEntryViewModel.Title = null;
            _addEntryViewModel.Amount = 0;
            _addEntryViewModel.Date = DateTime.Now;
            _addEntryViewModel.SelectedCategory = null;
        }
    }
}
