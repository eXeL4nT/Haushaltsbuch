using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace HouseholdBook.WPF.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly MainViewModel _viewModel;
        private readonly IHouseholdViewModelFactory _viewModelFactory;

        public UpdateViewCommand(MainViewModel viewModel, IHouseholdViewModelFactory viewModelFactory)
        {
            _viewModel = viewModel;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _viewModel.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
