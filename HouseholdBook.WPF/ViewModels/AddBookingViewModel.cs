using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class AddBookingViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; } = System.DateTime.Now.ToString("dd.MM.yyyy");
        public int CategoryId { get; set; }
        public int BankAccountId { get; set; }

        private Category category;
        public Category Category 
        {
            get => category;
            set => CategoryId = value.Id;
        }

        private BankAccount bankAccount;
        public BankAccount BankAccount
        {
            get => bankAccount;
            set => BankAccountId = value.Id;
        }

        private DateTime? dateTime;
        public DateTime? DateTime
        {
            get => dateTime;
            set
            {
                Date = value.Value.ToString("dd.MM.yyyy");
                dateTime = value;
            }
        }

        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(categories));
            }
        }

        private List<BankAccount> bankAccounts;
        public List<BankAccount> BankAccounts
        {
            get => bankAccounts;
            set
            {
                bankAccounts = value;
                OnPropertyChanged(nameof(bankAccounts));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand AddBookingCommand { get; set; }
        public ICommand GetCategoriesCommand { get; set; }
        public ICommand GetBankAccountsCommand { get; set; }

        public AddBookingViewModel(IBookingService bookingService, ICategoryService categoryService, IBankAccountService bankAccountService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            AddBookingCommand = new AddBookingCommand(this, bookingService);
            GetCategoriesCommand = new GetCategoriesCommand(this, categoryService);
            GetBankAccountsCommand = new GetBankAccountsCommand(this, bankAccountService);

            GetCategoriesCommand.Execute(null);
            GetBankAccountsCommand.Execute(null);
        }
    }
}
