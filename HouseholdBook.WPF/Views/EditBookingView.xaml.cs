using System;
using System.Windows;
using System.Windows.Controls;

namespace HouseholdBook.WPF.Views
{
    /// <summary>
    /// Interaktionslogik für EditBookingView.xaml
    /// </summary>
    public partial class EditBookingView : UserControl
    {
        //private readonly HouseholdContext householdContext = new HouseholdContext();
        //private Booking passedBooking;

        public EditBookingView()
        {
            InitializeComponent();

            //this.passedBooking = passedBooking as Booking;

            //PassBookingToTextBoxDataContext();
        }
        /*
        private void PassBookingToTextBoxDataContext()
        {
            tbTitle.DataContext = passedBooking;
            tbAmount.DataContext = passedBooking;
            dpDate.DataContext = passedBooking;
            //Category.DataContext = passedBooking;
            //BankAccount.DataContext = passedBooking;
        }
        */
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            /*
            UpdateFields();

            householdContext.SaveChanges();
            */
        }
        /*
        private void UpdateFields()
        {
            string bookingTitle = tbTitle.Text;
            double bookingAmount = Double.Parse(tbAmount.Text);
            DateTime bookingDate = (DateTime)dpDate.SelectedDate;

            passedBooking.Title = bookingTitle;
            passedBooking.Amount = bookingAmount;
            passedBooking.Date = bookingDate.ToString("dd.MM.yyyy");
        }
        */
    }
}
