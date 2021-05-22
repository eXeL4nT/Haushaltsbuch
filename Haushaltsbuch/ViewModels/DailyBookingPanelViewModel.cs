using Haushaltsbuch.Commands;
using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels;
using Haushaltsbuch.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Haushaltsbuch.ViewModels
{
    public class DailyBookingPanelViewModel : ViewModelBase
    {
        private readonly int _day;
        private ObservableCollection<BookingPanelViewModel> _bookingPanels = new ObservableCollection<BookingPanelViewModel>();

        public int Day => _day;

        public double DailyBalance
        {
            get
            {
                var dailyBalance = 0d;

                foreach (var bookingPanel in BookingPanels)
                {
                    dailyBalance += bookingPanel.Booking.BookingOption == 1 ? bookingPanel.Booking.Amount : bookingPanel.Booking.Amount * -1;
                }

                return dailyBalance;
            }
        }

        public ObservableCollection<BookingPanelViewModel> BookingPanels
        {
            get => _bookingPanels;
            set
            {
                if (_bookingPanels == value)
                    return;

                _bookingPanels = value;
                OnPropertyChanged(nameof(BookingPanels));
            }
        }

        public ICommand OpenChangeBookingDialogCommand { get; set; }

        public DailyBookingPanelViewModel(int day, List<Booking> bookings, IDialogService dialogService, IBookingService bookingService)
        {
            _day = day;
            bookings.ForEach(b => _bookingPanels.Add(new BookingPanelViewModel(b)));

            OpenChangeBookingDialogCommand = new OpenChangeBookingDialogCommand(dialogService, bookingService);
        }
    }
}
