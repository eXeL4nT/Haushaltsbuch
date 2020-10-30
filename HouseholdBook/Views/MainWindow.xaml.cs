using HouseholdBook.Models;
using HouseholdBook.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace HouseholdBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void BtnMainRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using HouseholdContext db = new HouseholdContext();

            List<Booking> bookings = db.Bookings.Include(t => t.Type).Include(c => c.Category).Include(b => b.BankAccount).ToList();
            dataGridBookings.ItemsSource = bookings;
        }

        private void BtnMainAddOutgoing_Click(object sender, RoutedEventArgs e)
        {
            AddOutgoingBookingView addOutgoingBookingView = new AddOutgoingBookingView();
            addOutgoingBookingView.Show();
        }

        private void BtnMainAddIncome_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeBookingView addIncomeBookingView = new AddIncomeBookingView();
            addIncomeBookingView.Show();
        }
    }
}
