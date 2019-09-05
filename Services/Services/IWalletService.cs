using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public interface IWalletService
    {
        WalletServiceModel GetWalletById(int id, bool includeAccounts = false);
        WalletServiceModel GetWalletByRegistrantId(int id, bool includeAccounts = false);
        WalletServiceModel GetWalletByWalletNumber(int walletNumber, bool includeAccounts = false);
        IEnumerable<WalletServiceModel> GetAllWallets();
        IEnumerable<WalletServiceModel> GetAllWallets(Expression<Func<WalletEntityModel, bool>> filter = null,
            Func<IQueryable<WalletEntityModel>, IOrderedQueryable<WalletEntityModel>> orderBy = null);
        IEnumerable<WalletServiceModel> GetAllWallets(string orderBy, string filter);
        int CreateWallet(WalletServiceModel wallet);
        void UpdateWallet(WalletServiceModel wallet);
        int DeleteRegistrant(int id);
    }
}
