using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using HouseholdBook.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public class BookingDataService : IDataService<Booking>
    {
        private readonly HouseholdDbContextFactory contextFactory;
        private readonly NonQueryDataService<Booking> nonQueryDataService;

        public BookingDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            this.nonQueryDataService = new NonQueryDataService<Booking>(contextFactory);
        }

        public async Task<Booking> Create(Booking entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<Booking> Get(int id)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Booking entity = await context.Bookings.Include(c => c.Category).Include(b => b.BankAccount).FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public async Task<Booking> Get(string name)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Booking entity = await context.Bookings.Include(c => c.Category).Include(b => b.BankAccount).FirstOrDefaultAsync(b => b.Title == name);

            return entity;
        }

        public async Task<IEnumerable<Booking>> GetAll()
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            IEnumerable<Booking> entities = await context.Bookings.Include(c => c.Category).Include(b => b.BankAccount).ToListAsync();

            return entities;
        }

        public async Task<Booking> Update(int id, Booking entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
