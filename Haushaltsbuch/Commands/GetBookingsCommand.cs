using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class GetBookingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel _overviewViewModel;
        private readonly IBookingService _bookingService;
        private readonly IDialogService _dialogService;

        public GetBookingsCommand(OverviewViewModel overviewViewModel, IBookingService bookingService, IDialogService dialogService)
        {
            _overviewViewModel = overviewViewModel;
            _bookingService = bookingService;
            _dialogService = dialogService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            _overviewViewModel.ErrorMessage = string.Empty;

            try
            {
                //_overviewViewModel.Bookings = await _bookingService.GetBookings(_overviewViewModel.SelectedMonth, _overviewViewModel.SelectedYear);
                /*
                var daysWithBookings = new Dictionary<int, List<Booking>>();

                for (int i = 31; i >= 1; i--)
                {
                    var dailyList = new List<Booking>();

                    foreach (var booking in bookings)
                    {
                        if (booking.Date.Day != i)
                            continue;

                        dailyList.Add(booking);
                    }

                    daysWithBookings.Add(i, dailyList);
                }

                foreach (var dayWithBookings in daysWithBookings)
                {
                    if (dayWithBookings.Value.Count <= 0)
                        continue;

                    _overviewViewModel.DailyBookings.Add(new DailyBookingOverviewViewModel(dayWithBookings.Key, dayWithBookings.Value));
                }
                */
            }
            catch (Exception e)
            {
                _overviewViewModel.ErrorMessage = $"Es ist ein Fehler beim Abrufen der Daten aufgetreten. {e.Message}";
            }
        }
    }
}
