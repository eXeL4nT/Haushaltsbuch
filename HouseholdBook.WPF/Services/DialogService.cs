using HouseholdBook.EntityFramework.Models;
using HouseholdBook.WPF.ViewModels;
using HouseholdBook.WPF.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HouseholdBook.WPF.Services
{
    public class DialogService : IDisposable
    {
        private static volatile DialogService instance;
        private static readonly object syncroot = new object();

        public DialogService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncroot)
                    {
                        if (instance == null)
                        {
                            instance = new DialogService();
                        }
                    }
                }
                return instance;
            }
        }

        public void ShowDialog(ViewModelBase viewModel, Booking booking)
        {
            var viewmodel = new ChangeBookingViewModel(booking);
            var view = new ChangeBookingView
            {
                DataContext = viewmodel,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                ResizeMode = ResizeMode.NoResize,
                WindowStyle = WindowStyle.None
            };
            
            view.ShowDialog();
        }

        public void Dispose()
        {
            ((IDisposable)instance).Dispose();
        }
    }
}
