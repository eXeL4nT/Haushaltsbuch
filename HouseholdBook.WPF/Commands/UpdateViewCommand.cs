using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MainViewModel viewModel;
        private readonly IHouseholdViewModelFactory viewModelFactory;

        public UpdateViewCommand(MainViewModel viewModel, IHouseholdViewModelFactory viewModelFactory)
        {
            this.viewModel = viewModel;
            this.viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                viewModel.CurrentViewModel = viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
