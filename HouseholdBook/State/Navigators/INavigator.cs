using HouseholdBook.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HouseholdBook.WPF.State.Navigators
{
    public enum ViewType
    {
        Overview,
        AddIncome,
        AddOutgoing,
        Edit
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
