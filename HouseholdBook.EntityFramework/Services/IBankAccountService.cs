﻿using HouseholdBook.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBook.EntityFramework.Services
{
    public interface IBankAccountService
    {
        Task<List<BankAccount>> GetBankAccounts();
    }
}