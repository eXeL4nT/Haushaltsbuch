using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class GetBankAccountsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddEntryViewModel addBookingViewModel;
        private readonly IBankAccountService bankAccountService;

        public GetBankAccountsCommand(AddEntryViewModel addBookingViewModel, IBankAccountService bankAccountService)
        {
            this.addBookingViewModel = addBookingViewModel;
            this.bankAccountService = bankAccountService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var bankAccounts = await bankAccountService.GetBankAccounts();
            addBookingViewModel.BankAccounts = bankAccounts;
        }
    }
}
