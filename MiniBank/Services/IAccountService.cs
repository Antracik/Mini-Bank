using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Services
{
    public interface IAccountService
    {
        AccountDbRepoModel GetAccountById(int id);
        IEnumerable<AccountDbRepoModel> GetAllAccounts();
        int CreateAccount(AccountModel account);
        void UpdateAccount(AccountModel account);
        int DeleteAccount(int id);
    }
}
