using HouseholdBook.Models;
using HouseholdBook.Views;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace HouseholdBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HouseholdContext objContext = new HouseholdContext();

        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void BtnMainRefresh_Click(object sender, RoutedEventArgs e) => LoadData();

        private void BtnMainDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Löschen?", "Löschen", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.Yes)
            {
                int bookingId = (dataGridBookings.SelectedItem as Booking).BookingId;
                Booking booking = objContext.Bookings.FirstOrDefault(id => id.BookingId == bookingId);
                objContext.Bookings.Remove(booking);
                objContext.SaveChanges();

                LoadData();
            }
        }

        private void BtnMainAddOutgoing_Click(object sender, RoutedEventArgs e)
        {
            AddOutgoingBookingView addOutgoingBookingView = new AddOutgoingBookingView
            {
                Top = Application.Current.MainWindow.Top,
                Left = Application.Current.MainWindow.Left
            };
            addOutgoingBookingView.ShowDialog();
        }

        private void BtnMainAddIncome_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeBookingView addIncomeBookingView = new AddIncomeBookingView
            {
                Top = Application.Current.MainWindow.Top,
                Left = Application.Current.MainWindow.Left
            };
            addIncomeBookingView.ShowDialog();
        }

        private void LoadData() => dataGridBookings.ItemsSource = objContext.Bookings.Include(t => t.Type).Include(c => c.Category).Include(b => b.BankAccount).ToList();
    }
}
