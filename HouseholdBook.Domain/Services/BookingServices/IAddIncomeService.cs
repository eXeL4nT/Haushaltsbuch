using HouseholdBook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.Domain.Services.BookingServices
{
    public interface IAddIncomeService
    {
        Task<Booking> AddIncome(Booking booking);
    }
}
