using Haushaltsbuch.Commands;
using Haushaltsbuch.Services;
using Haushaltsbuch.ViewModels.Base;
using Haushaltsbuch.ViewModels.Factories;
using ReactiveUI;
using System.Windows.Input;

namespace Haushaltsbuch.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ReactiveObject currentViewModel;

        public ReactiveObject CurrentViewModel
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
