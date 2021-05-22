using Haushaltsbuch.ViewModels.Base;
using ReactiveUI;

namespace Haushaltsbuch.ViewModels.Factories
{
    public interface IHouseholdViewModelFactory
    {
        ReactiveObject CreateViewModel(ViewType viewType);
    }
}
