using HouseholdBook.WPF.Commands;
using HouseholdBook.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(currentViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel(IHouseholdViewModelFactory viewModelFactory)
        {
            UpdateViewCommand = new UpdateViewCommand(this, viewModelFactory);
            UpdateViewCommand.Execute(ViewType.Overview);
        }
    }
}
