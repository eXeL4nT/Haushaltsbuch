using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
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

        public async Task<Booking> AddBooking(string title, double amount, string date, int categoryId, int bankAccountId)
        {
            
            if (string.IsNullOrEmpty(title)) throw new Exception("Der Titel darf nicht leer sein.");

            if (amount < 0.01) throw new Exception("Der Betrag darf nicht weniger als 0,01 € betragen.");

            if (string.IsNullOrEmpty(date)) throw new Exception("Das Datum darf nicht leer sein.");

            if (categoryId <= 0) throw new Exception("Keine Kategorie angegeben.");

            if (bankAccountId <= 0) throw new Exception("Kein Bank-Account angegeben.");

            Booking booking = new Booking() 
            { 
                Title = title, 
                Amount = amount, 
                Date = date, 
                CategoryId = categoryId, 
                BankAccountId = bankAccountId
            };

            await bookingDataService.Create(booking);

            return booking;
        }

        public async void DeleteBooking(int bookingId)
        {
            await bookingDataService.Delete(bookingId);
        }

        public async Task<List<Booking>> GetBookings()
        {
            List<Booking> bookings = (List<Booking>)await bookingDataService.GetAll();

            return bookings;
        }
    }
}
