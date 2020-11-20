using HouseholdBook.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.ViewModels.Factories
{
    public class HouseholdViewModelFactory : IHouseholdViewModelFactory
    {
        private readonly OverviewViewModel overviewViewModel;
        private readonly AddBookingViewModel addBookingViewModel;

        public HouseholdViewModelFactory(OverviewViewModel overviewViewModel, AddBookingViewModel addBookingViewModel)
        {
            this.overviewViewModel = overviewViewModel;
            this.addBookingViewModel = addBookingViewModel;
        }
        
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Overview:
                    return overviewViewModel;
                case ViewType.AddBooking:
                    return addBookingViewModel;
                case ViewType.Edit:
                    return new EditBookingViewModel();
                default:
                    throw new ArgumentException("Der ViewType besitzt kein ViewModel.", "viewType");
            }
        }
    }
}
