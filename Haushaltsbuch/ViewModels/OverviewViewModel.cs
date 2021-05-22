using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Commands;
using Haushaltsbuch.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Haushaltsbuch.ViewModels.Base;
using Haushaltsbuch.EntityFramework.Models;
using Technewlogic.WpfDialogManagement;
using ReactiveUI;
using System.Reactive.Linq;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Haushaltsbuch.ViewModels
{
    public class OverviewViewModel : ReactiveObject
    {
        private IBookingService _bookingService;
        private IDialogService _dialogService;
        private double _totalBalance;
        private List<int> _availableYears;
        private int _selectedMonth;
        private int _selectedYear;

        private ObservableAsPropertyHelper<IEnumerable<DailyBookingPanelViewModel>> _dailyBookingPanels;

        public IEnumerable<DailyBookingPanelViewModel> DailyBookingPanels => _dailyBookingPanels.Value;

        public double TotalBalance
        {
            get => _totalBalance;
            set => this.RaiseAndSetIfChanged(ref _totalBalance, value);
        }

        public List<int> AvailableMonths => new List<int> { 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

        public List<int> AvailableYears
        {
            get => _availableYears;
            set => this.RaiseAndSetIfChanged(ref _availableYears, value);
        }

        public int SelectedMonth
        {
            get => _selectedMonth;
            set => this.RaiseAndSetIfChanged(ref _selectedMonth, value);
        }

        public int SelectedYear
        {
            get => _selectedYear;
            set
            {
                if (_selectedYear == value)
                    return;

                _selectedYear = value;

                CreateBookingOverview();
            }
        }

        internal DialogBaseControl DialogPlaceholder { get; set; }

        public static OverviewViewModel Instance { get; private set; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand GetBookingsCommand { get; set; }
        public ICommand GetYearsCommand { get; set; }

        public OverviewViewModel(IBookingService bookingService, IDialogService dialogService)
        {
            Instance = this;

            ErrorMessageViewModel = new MessageViewModel();

            _bookingService = bookingService;
            _dialogService = dialogService;

            dialogService.Initialize(this);

            GetBookingsCommand = new GetBookingsCommand(this, bookingService, dialogService);
            GetYearsCommand = new GetYearsCommand(this, bookingService);

            GetYears();
            CreateBookingOverview();

            _dailyBookingPanels = this
                .Wh
                .SelectMany(GetBookings)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.DailyBookingPanels);
        }
        
        internal void GetYears()
        {
            GetYearsCommand.Execute(null);
        }

        private async Task<IEnumerable<DailyBookingPanelViewModel>> GetBookings(int selectedMonth, CancellationToken cancellationToken)
        {
            var bookings = await _bookingService.GetBookings(selectedMonth, selectedYear);

            var dailyBookingPanelViewModel = new List<DailyBookingPanelViewModel>
            {
                new DailyBookingPanelViewModel(1, bookings, _dialogService, _bookingService)
            };

            return dailyBookingPanelViewModel;
        }

        private void CreateBookingOverview()
        {
            //CreateDailyBookingPanels();
            //CalculateTotalBalance();
        }

        private void CreateDailyBookingPanels()
        {
            //DailyBookingPanels.Clear();

            //DailyBookingPanels = new ObservableCollection<DailyBookingPanelViewModel>();

            var daysWithBookings = new Dictionary<int, List<Booking>>();

            for (int i = 31; i >= 1; i--)
            {
                var dailyList = new List<Booking>();

                /*
                foreach (var booking in _bookings.Value)
                {
                    if (booking.Date.Day != i)
                        continue;

                    dailyList.Add(booking);
                }
                */

                daysWithBookings.Add(i, dailyList);
            }

            foreach (var dayWithBookings in daysWithBookings)
            {
                if (dayWithBookings.Value.Count <= 0)
                    continue;

                //DailyBookingPanels.Add(new DailyBookingPanelViewModel(dayWithBookings.Key, dayWithBookings.Value, _dialogService, _bookingService));
            }
        }

        private void CalculateTotalBalance()
        {
            var totalBalance = 0d;

            foreach (var dailyBooking in DailyBookingPanels)
            {
                totalBalance += dailyBooking.DailyBalance;
            }

            TotalBalance = totalBalance;
        }
    }
}
