﻿using Services.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IAccountService
    {
        AccountServiceModel GetAccountById(int id);
        IEnumerable<AccountServiceModel> GetAllAccounts();
        IEnumerable<AccountServiceModel> GetAllAccounts(string orderBy, string filter);
        int CreateAccount(AccountServiceModel account);
        void UpdateAccount(AccountServiceModel account);
        int DeleteAccount(int id);
    }
}
