﻿using Haushaltsbuch.EntityFramework.Models;
using Haushaltsbuch.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public class CategoryDataService : IDataService<Category>
    {
        private readonly HouseholdDbContextFactory contextFactory;
        private readonly NonQueryDataService<Category> nonQueryDataService;

        public CategoryDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            nonQueryDataService = new NonQueryDataService<Category>(contextFactory);
        }

        public async Task<Category> Create(Category entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<Category> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<Category> Get(int id)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Category entity = await context.Categories.FirstOrDefaultAsync((e) => e.Id == id);
            return entity;
        }

        public async Task<Category> Get(string description)
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            Category entity = await context.Categories.FirstOrDefaultAsync((e) => e.Name == description);
            return entity;
        }

        public Task<Category> Get(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> GetAll()
        {
            using HouseholdDbContext context = contextFactory.CreateDbContext();

            return await context.Categories.ToListAsync();
        }

        public async Task<Category> Update(int id, Category entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
