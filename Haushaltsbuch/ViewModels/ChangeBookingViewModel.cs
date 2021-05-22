using Haushaltsbuch.Commands;
using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels.Base;
using System.Windows.Input;

namespace Haushaltsbuch.ViewModels
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

        public MessageViewModel ErrorMessageViewModel { get; }
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public ICommand UpdateBookingCommand { get; set; }

        public ChangeBookingViewModel(Booking booking, IBookingService bookingService)
        {
            ErrorMessageViewModel = new MessageViewModel();

            //UpdateBookingCommand = new UpdateBookingCommand(this, OverviewViewModel.Instance, booking, bookingService, dialogService);

            _booking = booking;
        }
    }
}
