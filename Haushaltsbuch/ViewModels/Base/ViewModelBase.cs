using ReactiveUI;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Haushaltsbuch.ViewModels.Base
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ReactiveObject;

    public class ViewModelBase : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(e.Action));
        }
    }
}
