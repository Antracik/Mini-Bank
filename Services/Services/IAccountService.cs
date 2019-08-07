using System.Collections.Generic;

namespace Services.Models
{
    public interface IAccountService
    {
        AccountServiceModel GetAccountById(int id);
        IEnumerable<AccountServiceModel> GetAllAccounts();
        int CreateAccount(AccountServiceModel account);
        void UpdateAccount(AccountServiceModel account);
        int DeleteAccount(int id);
    }
}
