using Haushaltsbuch.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IDataService<BankAccount> bankAccountDataService;

        public BankAccountService(IDataService<BankAccount> bankAccountDataService)
        {
            this.bankAccountDataService = bankAccountDataService;
        }

        public async Task<List<BankAccount>> GetBankAccounts()
        {
            var bankAccounts = await bankAccountDataService.GetAll();

            return bankAccounts;
        }
    }
}
