﻿using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public class BookingDataService : IDataService<Booking>
    {
        private readonly HouseholdDbContextFactory contextFactory;
        private readonly NonQueryDataService<Booking> nonQueryDataService;

        public BookingDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            nonQueryDataService = new NonQueryDataService<Booking>(contextFactory);
        }

        public async Task<Booking> Create(Booking entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<Booking> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<Booking> Get(int id)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Booking entity = await context.Bookings.FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public Task<Booking> Get(string description)
        {
            throw new NotImplementedException();
        }

        public async Task<Booking> Get(Category category)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Booking entity = await context.Bookings.FirstOrDefaultAsync((c) => c.Category == category);
            return entity;
        }

        public async Task<List<Booking>> GetAll()
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            return await context.Bookings.Include(c => c.Category).Include(b => b.BankAccount).ToListAsync();
        }

        public async Task<List<Booking>> GetAll(int month, int year)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();
            return await context.Bookings.Where(x => x.Date.Year == year && x.Date.Month == month).Include(c => c.Category).Include(b => b.BankAccount).ToListAsync();
        }

        public async Task<Booking> Update(int id, Booking entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
