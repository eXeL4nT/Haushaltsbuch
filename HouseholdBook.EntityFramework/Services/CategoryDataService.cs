﻿using HouseholdBook.EntityFramework.Models;
using HouseholdBook.EntityFramework.Services.Common;
using Microsoft.AspNetCore.Mvc;
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