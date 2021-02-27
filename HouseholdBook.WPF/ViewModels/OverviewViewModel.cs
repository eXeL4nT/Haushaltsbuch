using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.WPF.Commands;
using HouseholdBook.WPF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        public ObservableCollection<BookingPanelViewModel> Bookings { get; set; } = new ObservableCollection<BookingPanelViewModel>();

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand GetBookingsCommand { get; set; }

        public OverviewViewModel(IBookingService bookingService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            Bookings.CollectionChanged += OnCollectionChanged;

            GetBookingsCommand = new GetBookingsCommand(this, bookingService);

            GetBookings();
        }

        private void GetBookings()
        {
            GetBookingsCommand.Execute(null);
        }
    }
}
