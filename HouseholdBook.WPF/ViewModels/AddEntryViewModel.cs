using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public delegate void CategoryCallback();

    public class AddEntryViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(Title);
            }
        }

        private double _amount;
        public double Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        private Category _selectedCategory;
        public Category SelectedCategory 
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private BankAccount _selectedBankAccount;
        public BankAccount SelectedBankAccount
        {
            get => _selectedBankAccount;
            set
            {
                _selectedBankAccount = value;
                OnPropertyChanged(nameof(SelectedBankAccount));
            }
        }

        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private IEnumerable<BankAccount> _bankAccounts;
        public IEnumerable<BankAccount> BankAccounts
        {
            get => _bankAccounts;
            set
            {
                _bankAccounts = value;
                OnPropertyChanged(nameof(BankAccounts));
            }
        }

        private string _newCategory;
        public string NewCategory
        {
            get => _newCategory;
            set
            {
                _newCategory = value;
                OnPropertyChanged(NewCategory);
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand AddBookingCommand { get; set; }
        public ICommand AddCategoryCommand { get; set; }
        public ICommand GetCategoriesCommand { get; set; }
        public ICommand GetBankAccountsCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public AddEntryViewModel(OverviewViewModel overviewViewModel, IBookingService bookingService, ICategoryService categoryService, IBankAccountService bankAccountService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            AddBookingCommand = new AddBookingCommand(this, bookingService, overviewViewModel.OnBookingsChanged);
            AddCategoryCommand = new AddCategoryCommand(this, categoryService, OnCategoriesChanged);
            GetCategoriesCommand = new GetCategoriesCommand(this, categoryService);
            GetBankAccountsCommand = new GetBankAccountsCommand(this, bankAccountService);
            DeleteCategoryCommand = new DeleteCategoryCommand(this, categoryService, OnCategoriesChanged);

            OnCategoriesChanged();
            GetBankAccountsCommand.Execute(null);
        }

        private void OnCategoriesChanged()
        {
            GetCategoriesCommand.Execute(null);
        }
    }
}
