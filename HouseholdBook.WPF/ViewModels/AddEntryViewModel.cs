using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{ 
    public class AddEntryViewModel : ViewModelBase
    {
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; } = System.DateTime.Now.ToString("dd.MM.yyyy");

        private Category _selectedCategory;
        public Category SelectedCategory 
        {
            get => _selectedCategory;
            set
            {
                if (value is null) return;

                _selectedCategory = value;
                OnPropertyChanged(nameof(_selectedCategory));
            }
        }

        private BankAccount _selectedBankAccount;
        public BankAccount SelectedBankAccount
        {
            get => _selectedBankAccount;
            set
            {
                if (value is null) return;

                _selectedBankAccount = value;
                OnPropertyChanged(nameof(_selectedBankAccount));
            }
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
        
        private ObservableCollection<Category> _searchResults = new ObservableCollection<Category>();
        public ObservableCollection<Category> SearchResults
        {
            get => _searchResults;
            set
            {
                _searchResults = value;
                OnPropertyChanged(nameof(_searchResults));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand AddBookingCommand { get; set; }
        public ICommand SearchCategoriesCommand { get; set; }
        public ICommand GetBankAccountsCommand { get; set; }

        public AddEntryViewModel(OverviewViewModel overviewViewModel, IBookingService bookingService, ICategoryService categoryService, IBankAccountService bankAccountService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            AddBookingCommand = new AddBookingCommand(this, bookingService, overviewViewModel.OnBookingsChanged);
            SearchCategoriesCommand = new SearchCategoriesCommand(this, categoryService);
            GetBankAccountsCommand = new GetBankAccountsCommand(this, bankAccountService);

            GetBankAccountsCommand.Execute(null);
        }
    }
}
