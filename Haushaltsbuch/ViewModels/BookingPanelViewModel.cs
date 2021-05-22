using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Commands;
using Haushaltsbuch.Services;
using System.Windows.Input;
using Haushaltsbuch.ViewModels.Base;

namespace Haushaltsbuch.ViewModels
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

        public BookingPanelViewModel(Booking booking)
        {
            _booking = booking;

            //DeleteEntryCommand = new DeleteEntryCommand(overviewViewModel, this, bookingService);
            //ChangeBookingCommand = new ShowUpdateBookingDialogCommand(booking, dialogService);
        }
    }
}
