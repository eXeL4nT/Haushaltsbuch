using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.ViewModels;
using System;
using System.Linq;
using System.Windows.Input;

namespace Haushaltsbuch.Commands
{
    public class GetYearsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly OverviewViewModel _overviewViewModel;
        private readonly IBookingService _bookingService;

        public GetYearsCommand(OverviewViewModel overviewViewModel, IBookingService bookingService)
        {
            _overviewViewModel = overviewViewModel;
            _bookingService = bookingService;
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
                var bookings = await _bookingService.GetBookings();

                var years = bookings.Select(booking => booking.Date.Year).ToHashSet();
                _overviewViewModel.AvailableYears = years.ToList();
            }
            catch (Exception e)
            {
                _overviewViewModel.ErrorMessage = $"Es ist ein Fehler beim Abrufen der Daten aufgetreten. {e.Message}";
            }
        }
    }
}
