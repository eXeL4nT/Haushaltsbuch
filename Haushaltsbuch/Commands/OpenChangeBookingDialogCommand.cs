using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class OpenChangeBookingDialogCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IDialogService _dialogService;
        private readonly IBookingService _bookingService;

        public OpenChangeBookingDialogCommand(IDialogService dialogService, IBookingService bookingService)
        {
            _dialogService = dialogService;
            _bookingService = bookingService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //_overviewViewModel.ErrorMessage = string.Empty;

            try
            {
                var changeBookingViewModel = new ChangeBookingViewModel(parameter as Booking, _bookingService);

                _dialogService.CreateChangeBookingDialog(changeBookingViewModel);
            }
            catch (Exception)
            {
                //_overviewViewModel.ErrorMessage = "Löschen der Buchungen ist fehlgeschlagen!";
            }
        }
    }
}
