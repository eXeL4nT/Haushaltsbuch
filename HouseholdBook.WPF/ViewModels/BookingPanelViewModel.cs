using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using HouseholdBook.WPF.Services;
using HouseholdBook.WPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class BookingPanelViewModel : ViewModelBase
    {
        private Booking _booking;
        public Booking Booking
        {
            get => _booking;
            set
            {
                _booking = value;
                OnPropertyChanged(nameof(Booking));
            }
        }

        public ICommand DeleteEntryCommand { get; set; }
        public ICommand ChangeBookingCommand { get; set; }

        public BookingPanelViewModel(OverviewViewModel overviewViewModel, Booking booking, IBookingService bookingService)
        {
            _booking = booking;

            DeleteEntryCommand = new DeleteEntryCommand(overviewViewModel, this, bookingService);
            ChangeBookingCommand = new ChangeBookingCommand(booking);
        }
    }
}
