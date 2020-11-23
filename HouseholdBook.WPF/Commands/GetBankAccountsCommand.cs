using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    public class GetBankAccountsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly AddBookingViewModel addBookingViewModel;
        private readonly IBankAccountService bankAccountService;

        public GetBankAccountsCommand(AddBookingViewModel addBookingViewModel, IBankAccountService bankAccountService)
        {
            this.addBookingViewModel = addBookingViewModel;
            this.bankAccountService = bankAccountService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            addBookingViewModel.BankAccounts = bankAccountService.GetBankAccounts().Result;
        }
    }
}
