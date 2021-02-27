using HouseholdBook.EntityFramework;
using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using HouseholdBook.WPF.Services;
using HouseholdBook.WPF.Views;
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

        private BookingOption _bookingOption;
        public BookingOption BookingOption
        {
            get => _bookingOption;
            set
            {
                _bookingOption = value;
                OnPropertyChanged(nameof(BookingOption));
            }
        }

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
        public ObservableCollection<BankAccount> BankAccounts { get; set; } = new ObservableCollection<BankAccount>();

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

            Categories.CollectionChanged += OnCollectionChanged;
            BankAccounts.CollectionChanged += OnCollectionChanged;

            AddBookingCommand = new AddBookingCommand(this, overviewViewModel, bookingService);
            AddCategoryCommand = new AddCategoryCommand(this, categoryService);
            GetCategoriesCommand = new GetCategoriesCommand(this, categoryService);
            GetBankAccountsCommand = new GetBankAccountsCommand(this, bankAccountService);
            DeleteCategoryCommand = new DeleteCategoryCommand(this, categoryService);

            GetCategories();
            GetBankAccounts();
        }

        private void GetCategories()
        {
            GetCategoriesCommand.Execute(null);
        }

        private void GetBankAccounts()
        {
            GetBankAccountsCommand.Execute(null);
        }
    }
}
