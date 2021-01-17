using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings();
        Task<Booking> AddBooking(string title, double amount, DateTime date, Category category, BankAccount bankAccount);
        Task<Booking> DeleteBooking(Booking booking);
    }
}
