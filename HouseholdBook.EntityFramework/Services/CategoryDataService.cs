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
    public class CategoryDataService : IDataService<Category>
    {
        private readonly HouseholdDbContextFactory contextFactory;
        private readonly NonQueryDataService<Category> nonQueryDataService;

        public CategoryDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            this.nonQueryDataService = new NonQueryDataService<Category>(contextFactory);
        }

        public async Task<Category> Create(Category entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<Category> Get(int id)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Category entity = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            return entity;
        }

        public async Task<Category> Get(string name)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Category entity = await context.Categories.FirstOrDefaultAsync(c => c.Name == name);

            return entity;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            IEnumerable<Category> entities = await context.Categories.ToListAsync();

            return entities;
        }

        public async Task<Category> Update(int id, Category entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
