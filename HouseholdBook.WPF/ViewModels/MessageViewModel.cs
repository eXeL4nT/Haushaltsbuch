using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
    }
}
