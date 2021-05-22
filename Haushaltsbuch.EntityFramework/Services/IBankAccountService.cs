using Haushaltsbuch.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch.EntityFramework.Services
{
    public interface IBankAccountService
    {
        Task<List<BankAccount>> GetBankAccounts();
    }
}
