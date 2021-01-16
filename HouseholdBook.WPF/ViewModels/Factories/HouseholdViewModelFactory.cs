using HouseholdBook.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.ViewModels.Factories
{
    public class HouseholdViewModelFactory : IHouseholdViewModelFactory
    {
        private readonly OverviewViewModel _overviewViewModel;
        private readonly AddEntryViewModel _addEntryViewModel;

        public HouseholdViewModelFactory(OverviewViewModel overviewViewModel, AddEntryViewModel addEntryViewModel)
        {
            _overviewViewModel = overviewViewModel;
            _addEntryViewModel = addEntryViewModel;
        }
        
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Overview:
                    return _overviewViewModel;
                case ViewType.AddEntry:
                    return _addEntryViewModel;
                case ViewType.Edit:
                    return new EditBookingViewModel();
                default:
                    throw new ArgumentException("Der ViewType besitzt kein ViewModel.", "viewType");
            }
        }
    }
}
