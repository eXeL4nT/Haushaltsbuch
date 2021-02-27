using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookingDataService bookingDataService;

        public BookingService(BookingDataService bookingDataService)
        {
            this.bookingDataService = bookingDataService;
        }

        public async Task<Booking> AddBooking(string title, double amount, DateTime date, BookingOption bookingOption, Category category, BankAccount bankAccount)
        {
            
            if (string.IsNullOrEmpty(title) || title.Length < 3) throw new Exception("Bitte einen Titel eintragen mit mindestens 3 Zeichen angeben.");
            if (amount < 0.01) throw new Exception("Bitte einen Betrag von mindestens 0,01 € eintragen.");
            if (category is null) throw new Exception("Es wurde keine Kategorie angegeben.");
            if (bankAccount is null) throw new Exception("Es wurde kein Konto ausgewählt.");

            if (bookingOption == BookingOption.Expenditure)
            {
                amount *= -1;
            }

            Booking booking = new Booking()
            {
                Title = title,
                Amount = amount,
                Date = date.ToString("dd.MM.yyyy"),
                BookingOption = (int) bookingOption,
                CategoryId = category.Id, 
                BankAccountId = bankAccount.Id
            };

            return await bookingDataService.Create(booking);
        }

        public async Task<Booking> DeleteBooking(Booking booking)
        {
            return await bookingDataService.Delete(booking.Id);
        }

        public async Task<ObservableCollection<Booking>> GetBookings()
        {
            ObservableCollection<Booking> bookings = await bookingDataService.GetAll();

            return bookings;
        }
    }
}
