using HouseholdBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.Domain.Services.BookingServices
{
    public class AddIncomeService : IAddIncomeService
    {
        private readonly IDataService<Booking> bookingService;

        public AddIncomeService(IDataService<Booking> bookingService)
        {
            this.bookingService = bookingService;
        }

        public async Task<Booking> AddIncome(Booking booking)
        {
            await bookingService.Update(booking.Id, booking);

            return booking;
        }
    }
}
