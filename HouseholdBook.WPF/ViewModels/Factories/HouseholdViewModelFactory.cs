using HouseholdBook.EntityFramework;
using HouseholdBook.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.ViewModels.Factories
{
    public class HouseholdViewModelFactory : IHouseholdViewModelFactory
    {
        private readonly CreateViewModel<OverviewViewModel> _createOverviewViewModel;
        private readonly CreateViewModel<AddEntryViewModel> _createAddEntryViewModel;

        public HouseholdViewModelFactory(CreateViewModel<OverviewViewModel> createOverviewViewModel, CreateViewModel<AddEntryViewModel> createAddEntryViewModel)
        {
            _createOverviewViewModel = createOverviewViewModel;
            _createAddEntryViewModel = createAddEntryViewModel;
        }
        
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Overview:
                    return _createOverviewViewModel();
                case ViewType.AddEntry:
                    return _createAddEntryViewModel();
                case ViewType.Edit:
                    return new EditBookingViewModel();
                default:
                    throw new ArgumentException("Der ViewType besitzt kein ViewModel.", "viewType");
            }
        }
    }
}
