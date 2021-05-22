using Haushaltsbuch.ViewModels.Base;
using ReactiveUI;
using System;

namespace Haushaltsbuch.ViewModels.Factories
{
    public class HouseholdViewModelFactory : IHouseholdViewModelFactory
    {
        private readonly CreateViewModel<OverviewViewModel> _createOverviewViewModel;
        private readonly CreateViewModel<AddEntryViewModel> _createAddEntryViewModel;

        public HouseholdViewModelFactory(CreateViewModel<OverviewViewModel> createOverviewViewModel,
            CreateViewModel<AddEntryViewModel> createAddEntryViewModel)
        {
            _createOverviewViewModel = createOverviewViewModel;
            _createAddEntryViewModel = createAddEntryViewModel;
        }
        
        public ReactiveObject CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Overview:
                    return _createOverviewViewModel();
                case ViewType.AddEntry:
                    return _createAddEntryViewModel();
                default:
                    throw new ArgumentException("Der ViewType besitzt kein ViewModel.", "viewType");
            }
        }
    }
}
