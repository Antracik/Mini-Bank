using Services.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IWalletService
    {
        WalletServiceModel GetWalletById(int id, bool includeAccounts = false);
        IEnumerable<WalletServiceModel> GetAllWallets();
        int CreateWallet(WalletServiceModel wallet);
        void UpdateWallet(WalletServiceModel wallet);
        int DeleteRegistrant(int id);
    }
}
