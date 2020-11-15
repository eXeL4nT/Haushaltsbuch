using HouseholdBook.Domain.Models;
using HouseholdBook.Domain.Services;
using HouseholdBook.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public class BankAccountDataService : IDataService<BankAccount>
    {
        private readonly HouseholdDbContextFactory contextFactory;
        private readonly NonQueryDataService<BankAccount> nonQueryDataService;

        public BankAccountDataService(HouseholdDbContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
            this.nonQueryDataService = new NonQueryDataService<BankAccount>(contextFactory);
        }

        public async Task<BankAccount> Create(BankAccount entity)
        {
            return await nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await nonQueryDataService.Delete(id);
        }

        public async Task<BankAccount> Get(int id)
        {
            using (HouseholdDbContext context = contextFactory.CreateDbContext())
            {
                BankAccount entity = await context.BankAccounts.FirstOrDefaultAsync(b => b.Id == id);

                return entity;
            }
        }

        public async Task<BankAccount> Get(string name)
        {
            using (HouseholdDbContext context = contextFactory.CreateDbContext())
            {
                BankAccount entity = await context.BankAccounts.FirstOrDefaultAsync(b => b.Name == name);

                return entity;
            }
        }

        public async Task<IEnumerable<BankAccount>> GetAll()
        {
            using (HouseholdDbContext context = contextFactory.CreateDbContext())
            {
                IEnumerable<BankAccount> entities = await context.BankAccounts.ToListAsync();

                return entities;
            }
        }

        public async Task<BankAccount> Update(int id, BankAccount entity)
        {
            return await nonQueryDataService.Update(id, entity);
        }
    }
}
