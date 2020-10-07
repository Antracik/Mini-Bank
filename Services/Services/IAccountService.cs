using Services.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IAccountService
    {
        AccountServiceModel GetAccountById(int id);
        AccountServiceModel GetAccountByIBAN(string IBAN);
        IEnumerable<AccountServiceModel> GetAllAccounts();
        IEnumerable<AccountServiceModel> GetAllAccountsWithWalledId(int walletId);
        IEnumerable<AccountServiceModel> GetAllAccounts(string orderBy, string filter);
        int CreateAccount(AccountServiceModel account);
        void UpdateAccount(AccountServiceModel account);
        int DeleteAccount(int id);
    }
}
