using HouseholdBook.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseholdBook.WPF.ViewModels.Factories
{
    public interface IHouseholdViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
