using System.Collections.Generic;

namespace Services.Models
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
