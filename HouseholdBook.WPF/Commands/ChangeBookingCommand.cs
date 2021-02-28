using HouseholdBook.EntityFramework.Models;
using HouseholdBook.WPF.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class ChangeBookingCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Booking _booking;

        public ChangeBookingCommand(Booking booking)
        {
            _booking = booking;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var dialogService = new DialogService();
            dialogService.Instance.ShowDialog(_booking);
        }
    }
}
