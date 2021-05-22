using Haushaltsbuch.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Technewlogic.WpfDialogManagement;

namespace Haushaltsbuch.Services
{
    public class DialogService : IDialogService
    {
        private DialogManager _dialogManager;

        public DialogService()
        {
            _dialogManager = new DialogManager(Application.Current.Dispatcher);
        }

        public void Initialize(OverviewViewModel overviewViewModel)
        {
            _dialogManager.Initialize(overviewViewModel);
        }

        public void CreateChangeBookingDialog(object content)
        {
            if (!_dialogManager.IsInitialized)
                return;

            _dialogManager.CreateCustomContentDialog(content, DialogMode.OkCancel).Show();
        }
    }
}
