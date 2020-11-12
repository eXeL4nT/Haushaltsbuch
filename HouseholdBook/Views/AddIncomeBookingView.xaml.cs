using HouseholdBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HouseholdBook
{
    /// <summary>
    /// Interaktionslogik für AddBooking.xaml
    /// </summary>
    public partial class AddIncomeBookingView : Window
    {
        private HouseholdContext objContext = new HouseholdContext();

        public AddIncomeBookingView()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            objContext.Bookings.Add(CreateBookingEntry());
            objContext.SaveChanges();
        }

        private void ComboBoxCategory_Initialized(object sender, EventArgs e)
        {
            List<Category> categories = objContext.Categories.ToList();

            foreach (Category category in categories)
            {
                comboBoxCategory.Items.Add(category.Title);
            }

            comboBoxCategory.SelectedIndex = 0;
        }

        private void ComboBoxBankAccount_Initialized(object sender, EventArgs e)
        {
            List<BankAccount> bankAccounts = objContext.BankAccounts.ToList();

            foreach (BankAccount bankAccount in bankAccounts)
            {
                comboBoxBankAccount.Items.Add(bankAccount.Name);
            }

            comboBoxBankAccount.SelectedIndex = 0;
        }

        private Booking CreateBookingEntry()
        {
            Category bookingCategory = SearchCategory(comboBoxCategory.SelectedItem.ToString());
            BankAccount bookingBankAccount = SearchBankAccount(comboBoxBankAccount.SelectedItem.ToString());
            DateTime bookingDate = (DateTime)datePickerBooking.SelectedDate;

            return new Booking { Title = textBoxTitle.Text, Amount = Double.Parse(textBoxAmount.Text), Date = bookingDate.ToString("dd.MM.yyyy"), Category = bookingCategory, BankAccount = bookingBankAccount };
        }

        private BankAccount SearchBankAccount(string selectedBankAccount)
        {
            return objContext.BankAccounts.Where(bankAccount => bankAccount.Name.Contains(selectedBankAccount)).FirstOrDefault();
        }

        private Category SearchCategory(string selectedCategory)
        {
            return objContext.Categories.Where(category => category.Title.Contains(selectedCategory)).FirstOrDefault();
        }
    }
}
