using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.Commands
{
    public class AsyncCommand : IAsyncCommand
    {
        private bool _isExecuting;
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public AsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute()
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }
            }

            OnCanExecuteChanged();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}
