using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.ViewModels
{
    public class ChangeBookingViewModel : ViewModelBase
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

        public ChangeBookingViewModel(Booking booking)
        {
            _booking = booking;
        }
    }
}
