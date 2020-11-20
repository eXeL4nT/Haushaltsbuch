using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    class GetBookingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel viewModel;
        private readonly IDataService<Booking> bookingService;

        public GetBookingsCommand(OverviewViewModel viewModel, IDataService<Booking> bookingService)
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
            List<Booking> bookings = (List<Booking>) await bookingService.GetAll();
            viewModel.Bookings = bookings;
        }
    }
}
