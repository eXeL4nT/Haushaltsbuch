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

        public async Task<Booking> AddBooking(string title, double amount, DateTime date, Category category, BankAccount bankAccount)
        {
            
            if (string.IsNullOrEmpty(title)) throw new Exception("Der Titel darf nicht leer sein.");
            if (amount < 0.01) throw new Exception("Der Betrag darf nicht weniger als 0,01 € betragen.");
            if (category is null) throw new Exception("Keine Kategorie angegeben.");
            if (bankAccount is null) throw new Exception("Kein Bank-Account angegeben.");

            Booking booking = new Booking() 
            { 
                Title = title, 
                Amount = amount, 
                Date = date.ToString("dd.MM.yyyy"), 
                CategoryId = category.Id, 
                BankAccountId = bankAccount.Id
            };

            return await bookingDataService.Create(booking);
        }

        public async void DeleteBooking(Booking booking)
        {
            await bookingDataService.Delete(booking.Id);
        }

        public async Task<List<Booking>> GetBookings()
        {
            List<Booking> bookings = (List<Booking>)await bookingDataService.GetAll();

            return bookings;
        }
    }
}
