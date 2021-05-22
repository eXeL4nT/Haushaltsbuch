using Haushaltsbuch.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings();
        Task<List<Booking>> GetBookings(int month, int year);
        Task<Booking> AddBooking(string title, double amount, DateTime date, int bookingOption, Category category, BankAccount bankAccount);
        Task<Booking> UpdateBooking(Booking booking);
        Task<Booking> DeleteBooking(Booking booking);
    }
}
