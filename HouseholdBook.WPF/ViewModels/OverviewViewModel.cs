using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        private ICollection<Booking> bookings;
        public ICollection<Booking> Bookings
        {
            get => bookings;
            set
            {
                bookings = value;
                OnPropertyChanged(nameof(bookings));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand GetBookingsCommand { get; set; }

        public OverviewViewModel(IBookingService bookingService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            GetBookingsCommand = new GetBookingsCommand(this, bookingService);
            GetBookingsCommand.Execute(null);
        }
    }
}
