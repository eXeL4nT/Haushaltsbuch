using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public delegate void BookingCallback();

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

        private Booking _selectedBooking;
        public Booking SelectedBooking
        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
                OnPropertyChanged(nameof(_selectedBooking));
            }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand GetBookingsCommand { get; set; }
        public ICommand DeleteEntryCommand { get; set; }

        public OverviewViewModel(IBookingService bookingService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            GetBookingsCommand = new GetBookingsCommand(this, bookingService);
            DeleteEntryCommand = new DeleteEntryCommand(this, bookingService, OnBookingsChanged);

            OnBookingsChanged();
        }

        public void OnBookingsChanged()
        {
            GetBookingsCommand.Execute(null);
        }
    }
}
