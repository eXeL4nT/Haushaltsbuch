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

        private readonly AddBookingViewModel viewModel;
        private readonly IDataService<Booking> bookingService;

        public AddBookingCommand(AddBookingViewModel viewModel, IDataService<Booking> bookingService)
        {
            this.viewModel = viewModel;
            this.bookingService = bookingService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await bookingService.Create(new Booking { Title = viewModel.Title, Amount = viewModel.Amount, Date = viewModel.Date, Category = viewModel.Category, BankAccount = viewModel.BankAccount });
        }
    }
}
