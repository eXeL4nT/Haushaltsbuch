using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : BaseModel
    {
        private readonly HouseholdDbContextFactory contextFactory;

        public NonQueryDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return createdResult.Entity;
        }

        public async Task<T> Delete(int id)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            T entity = await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            EntityEntry<T> deletedResult = context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return deletedResult.Entity;
        }

        public async Task<T> Update(int id, T entity)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            entity.Id = id;

            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
