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
            
            if (string.IsNullOrEmpty(title))
            {
                throw new Exception();
            }

            if (amount < 0.1)
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(date))
            {
                throw new Exception();
            }

            if (categoryId <= 0)
            {
                throw new Exception();
            }

            if (bankAccountId <= 0)
            {
                throw new Exception();
            }

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

        public async Task<List<Booking>> GetBookings()
        {
            List<Booking> bookings = (List<Booking>)await bookingDataService.GetAll();

            return bookings;
        }
    }
}
