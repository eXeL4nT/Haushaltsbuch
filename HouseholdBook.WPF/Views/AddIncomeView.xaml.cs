using System;
using System.Windows;
using System.Windows.Controls;

namespace HouseholdBook.WPF.Views
{
    /// <summary>
    /// Interaktionslogik für AddIncomeView.xaml
    /// </summary>
    public partial class AddIncomeView : UserControl
    {
        //private readonly HouseholdContext householdContext = new HouseholdContext();

        public AddIncomeView()
        {
            InitializeComponent();
        }
        
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            /*
            householdContext.Bookings.Add(CreateBookingEntry());
            householdContext.SaveChanges();
            */
        }
        
        private void ComboBoxCategory_Initialized(object sender, EventArgs e)
        {
            /*
            List<Category> categories = householdContext.Categories.ToList();

            foreach (Category category in categories)
            {
                comboBoxCategory.Items.Add(category.Name);
            }

            comboBoxCategory.SelectedIndex = 0;
            */
        }

        private void ComboBoxBankAccount_Initialized(object sender, EventArgs e)
        {
            /*
            List<BankAccount> bankAccounts = householdContext.BankAccounts.ToList();

            foreach (BankAccount bankAccount in bankAccounts)
            {
                comboBoxBankAccount.Items.Add(bankAccount.Name);
            }

            comboBoxBankAccount.SelectedIndex = 0;
            */
        }
        /*
        private Booking CreateBookingEntry()
        {
            Category bookingCategory = SearchCategory(comboBoxCategory.SelectedItem.ToString());
            BankAccount bookingBankAccount = SearchBankAccount(comboBoxBankAccount.SelectedItem.ToString());
            DateTime bookingDate = (DateTime)datePickerBooking.SelectedDate;

            return new Booking { Title = textBoxTitle.Text, Amount = Double.Parse(textBoxAmount.Text), Date = bookingDate.ToString("dd.MM.yyyy"), Category = bookingCategory, BankAccount = bookingBankAccount };
        }

        private BankAccount SearchBankAccount(string selectedBankAccount)
        {
            return householdContext.BankAccounts.Where(bankAccount => bankAccount.Name.Contains(selectedBankAccount)).FirstOrDefault();
        }

        private Category SearchCategory(string selectedCategory)
        {
            return householdContext.Categories.Where(category => category.Name.Contains(selectedCategory)).FirstOrDefault();
        }
        */
    }
    }
