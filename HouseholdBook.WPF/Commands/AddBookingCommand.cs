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
        public event EventHandler CanExecuteChanged;

        private readonly AddBookingViewModel addBookingViewModel;
        private readonly IBookingService bookingService;

        public AddBookingCommand(AddBookingViewModel addBookingViewModel, IBookingService bookingService)
        {
            this.addBookingViewModel = addBookingViewModel;
            this.bookingService = bookingService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            addBookingViewModel.ErrorMessage = string.Empty;

            try
            {   
                await bookingService.AddBooking(addBookingViewModel.Title, addBookingViewModel.Amount, addBookingViewModel.Date, addBookingViewModel.CategoryId, addBookingViewModel.BankAccountId);
            }
            catch (Exception e)
            {
                addBookingViewModel.ErrorMessage = e.Message;
            }
        }
    }
}
