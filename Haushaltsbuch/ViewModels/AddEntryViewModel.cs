using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Commands;
using Haushaltsbuch.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Haushaltsbuch.ViewModels.Base;
using System.Threading.Tasks;
using ReactiveUI;
using System.Collections.Generic;
using System.Reactive;

namespace Haushaltsbuch.ViewModels
{
    public class AddEntryViewModel : ReactiveObject
    {
        private readonly ICategoryService _categoryService;
        private readonly IBankAccountService _bankAccountService;

        private string _title;
        private string _newCategory;
        private int _bookingOption;
        private double _amount;
        private Category _selectedCategory;
        private BankAccount _selectedBankAccount;
        private DateTime _date = DateTime.Now;

        private List<Category>_categories;
        private List<BankAccount> _bankAccounts;

        public string Title
        {
            get => _title;
            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        public string NewCategory
        {
            get => _newCategory;
            set => this.RaiseAndSetIfChanged(ref _newCategory, value);
        }

        public double Amount
        {
            get => _amount;
            set => this.RaiseAndSetIfChanged(ref _amount, value);
        }

        public Category SelectedCategory 
        {
            get => _selectedCategory;
            set => this.RaiseAndSetIfChanged(ref _selectedCategory, value);
        }

        public BankAccount SelectedBankAccount
        {
            get => _selectedBankAccount;
            set => this.RaiseAndSetIfChanged(ref _selectedBankAccount, value);
        }

        public DateTime Date
        {
            get => _date;
            set => this.RaiseAndSetIfChanged(ref _date, value);
        }

        public int BookingOption
        {
            get => _bookingOption;
            set => this.RaiseAndSetIfChanged(ref _bookingOption, value);
        }

        public List<Category> Categories
        {
            get => _categories;
            set => this.RaiseAndSetIfChanged(ref _categories, value);
        }

        public List<BankAccount> BankAccounts
        {
            get => _bankAccounts;
            set => this.RaiseAndSetIfChanged(ref _bankAccounts, value);
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ReactiveCommand<Unit, Task> AddBookingCommand { get; }
        public ICommand AddCategoryCommand { get; set; }
        public ICommand GetCategoriesCommand { get; set; }
        public ICommand GetBankAccountsCommand { get; set; }
        public ICommand DeleteCategoryCommand { get; set; }

        public AddEntryViewModel(OverviewViewModel overviewViewModel, IBookingService bookingService,
            ICategoryService categoryService, IBankAccountService bankAccountService)
        {
            _categoryService = categoryService;
            _bankAccountService = bankAccountService;

            ErrorMessageViewModel = new MessageViewModel();

            //AddBookingCommand = new AddBookingCommand(this, overviewViewModel, bookingService, dialogService);
            /*AddBookingCommand = new AsyncCommand(async () =>
            {
                ErrorMessage = string.Empty;

                try
                {
                    var booking = await bookingService.AddBooking(Title, Amount, Date, BookingOption, SelectedCategory, SelectedBankAccount);
                    //_overviewViewModel.Bookings.Add(new BookingPanelViewModel(_overviewViewModel, booking, _bookingService, _dialogService));

                    overviewViewModel.GetYears();

                    Cleanup();
                }
                catch (Exception e)
                {
                    ErrorMessage = $"Es ist ein Fehler aufgetreten. {e.Message}";
                }
            });
            */

            AddBookingCommand = ReactiveCommand.Create(async () =>
            {
                ErrorMessage = string.Empty;

                try
                {
                    await bookingService.AddBooking(Title, Amount, Date, BookingOption, SelectedCategory, SelectedBankAccount);
                }
                catch (Exception e)
                {
                    ErrorMessage = $"Es ist ein Fehler aufgetreten. {e.Message}";
                }
            });

            AddCategoryCommand = new AddCategoryCommand(this, categoryService);
            GetCategoriesCommand = new GetCategoriesCommand(this, categoryService);
            GetBankAccountsCommand = new GetBankAccountsCommand(this, bankAccountService);
            DeleteCategoryCommand = new DeleteCategoryCommand(this, categoryService);

            GetCategories();
            GetBankAccounts();
        }

        private async void GetCategories()
        {
            Categories = await _categoryService.GetCategories();
        }

        private async void GetBankAccounts()
        {
            BankAccounts = await _bankAccountService.GetBankAccounts();
        }

        public void Cleanup()
        {
            Title = null;
            Amount = 0;
            Date = DateTime.Now;
            //_addEntryViewModel.BookingOption = 0;
            SelectedCategory = null;
        }
    }
}
