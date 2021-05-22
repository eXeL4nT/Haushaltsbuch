using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
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

        public async Task<List<T>> GetAll()
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(int id, T entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
