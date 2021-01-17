using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : BaseModel
    {
        private readonly HouseholdDbContextFactory contextFactory;
        private readonly NonQueryDataService<T> nonQueryDataService;

        public GenericDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<T> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(int id)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public Task<T> Get(string description)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            IEnumerable<T> entities = await context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> Update(int id, T entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
