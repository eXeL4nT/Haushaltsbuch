using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public interface IBookingService
    {
        Task<Booking> AddBooking(string title, double amount, string date, int categoryId, int bankAccountId);
        Task<List<Booking>> GetBookings();
        void DeleteBooking(int bookingId);
    }
}
