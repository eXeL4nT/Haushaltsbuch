using HouseholdBook.WPF.State.Navigators;
using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        private INavigator navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("test");
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                switch (viewType)
                {
                    case ViewType.Overview:
                        navigator.CurrentViewModel = new OverviewViewModel();
                        break;
                    case ViewType.AddIncome:
                        navigator.CurrentViewModel = new AddIncomeViewModel();
                        break;
                    case ViewType.AddOutgoing:
                        navigator.CurrentViewModel = new AddOutgoingViewModel();
                        break;
                    case ViewType.Edit:
                        navigator.CurrentViewModel = new EditBookingViewModel();
                        break;
                }
            }
        }
    }
}
