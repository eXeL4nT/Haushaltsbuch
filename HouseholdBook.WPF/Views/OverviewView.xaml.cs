using System.Windows;
using System.Windows.Controls;

namespace HouseholdBook.WPF.Views
{
    /// <summary>
    /// Interaktionslogik für OverviewView.xaml
    /// </summary>
    public partial class OverviewView : UserControl
    {
        //private readonly HouseholdContext householdContext = new HouseholdContext();

        public OverviewView()
        {
            InitializeComponent();
            //InitializeOverview();
        }
        /*
        private void InitializeOverview()
        {
            LoadBookingsFromDatabase();
            AssignBookingsToDataGrid(GetBookingsAsView());
        }

        private void AssignBookingsToDataGrid(ListCollectionView allBookings)
        {
            DgBookings.ItemsSource = allBookings;
        }

        private ListCollectionView GetBookingsAsView()
        {
            ListCollectionView allBookings = new ListCollectionView(householdContext.Bookings.Local.ToList());

            //Hinzufügen der Eigenschaft MonthOfDate, damit die Buchungen nach dem Monat gruppiert werden.
            allBookings.GroupDescriptions.Add(new PropertyGroupDescription("MonthOfDate"));

            return allBookings;
        }

        private void LoadBookingsFromDatabase()
        {
            householdContext.Bookings.Include(bankAccount => bankAccount.BankAccount).Include(category => category.Category).Load();
        }
        */
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            /*
            InitializeOverview();
            */
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            /*
            int bookingId = (DgBookings.SelectedItem as Booking).Id;
            Booking booking = householdContext.Bookings.FirstOrDefault(i => i.Id == bookingId);
            householdContext.Bookings.Remove(booking);
            householdContext.SaveChanges();

            InitializeOverview();
            */
        }
        
        private void DgBookings_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*
            IInputElement selectedElement = e.MouseDevice.DirectlyOver;

            CreateEditBookingView(selectedElement, sender);
            */
        }
        /*
        private bool CheckIfSelectedElementIsValid(IInputElement selectedElement, object sender)
        {
            if (selectedElement != null && selectedElement is FrameworkElement)
            {
                if (((FrameworkElement)selectedElement).Parent is DataGridCell)
                {
                    var grid = sender as DataGrid;

                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void CreateEditBookingView(IInputElement selectedElement, object sender)
        {
            if (CheckIfSelectedElementIsValid(selectedElement, sender))
            {
                var grid = sender as DataGrid;
                var selectedBooking = grid.SelectedItem;

                //EditBookingView editBookingView = new EditBookingView(selectedBooking);
                //editBookingView.ShowDialog();
            }
        }
        */
        }
    }
