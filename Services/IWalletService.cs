using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Services
{
    public interface IWalletService
    {
        WalletDbRepoModel GetWalletById(int id, bool includeAccounts = false);
        IEnumerable<WalletDbRepoModel> GetAllWallets();
        int CreateWallet(WalletModel wallet);
        void UpdateWallet(WalletModel wallet);
        int DeleteRegistrant(int id);
    }
}
