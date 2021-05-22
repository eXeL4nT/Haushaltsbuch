using Haushaltsbuch.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haushaltsbuch.Services
{
    public interface IDialogService
    {
        void Initialize(OverviewViewModel overviewViewModel);
        void CreateChangeBookingDialog(object content);
    }
}
