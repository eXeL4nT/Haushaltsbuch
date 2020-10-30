using HouseholdBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HouseholdBook
{
    /// <summary>
    /// Interaktionslogik für AddBooking.xaml
    /// </summary>
    public partial class AddIncomeBookingView : Window
    {
        public AddIncomeBookingView()
        {
            InitializeComponent();
        }

        private void btnAddBooking_Click(object sender, RoutedEventArgs e)
        {
            using HouseholdContext db = new HouseholdContext();
            
            //Booking newBooking = new Booking { Title = tBoxAddBookingTitle.Text, Amount = Double.Parse(tBoxAddBookingAmount.Text), Date = dPickerAddBooking.SelectedDate.ToString(), BankAccount = (BankAccount) cBoxAddBookingBankAccount.SelectedItem, Category = (Category) cBoxAddBookingCategory.SelectedItem};
            //db.Add(newBooking);
            //db.SaveChanges();
        }

        private void cBoxAddBookingCategory_Initialized(object sender, EventArgs e)
        {
            using HouseholdContext db = new HouseholdContext();

            List<Category> categories = db.Categories.ToList();

            foreach (Category category in categories)
            {
                //cBoxAddBookingCategory.Items.Add(category.Title);
            }

            //cBoxAddBookingCategory.SelectedIndex = 0;
        }

        private void cBoxAddBookingBankAccount_Initialized(object sender, EventArgs e)
        {
            using HouseholdContext db = new HouseholdContext();

            List<BankAccount> bankAccounts = db.BankAccounts.ToList();

            foreach (BankAccount bankAccount in bankAccounts)
            {
                //cBoxAddBookingBankAccount.Items.Add(bankAccount.Name);
            }

            //cBoxAddBookingBankAccount.SelectedIndex = 0;
        }
    }
}
