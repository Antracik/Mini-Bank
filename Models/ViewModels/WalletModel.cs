using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models
{
    public class WalletModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public StatusModel.Status WalletStatus { get; set; }
        public List<AccountModel> Accounts { get; set; }
        public bool IsVerified { get; set; }

        public WalletModel(int id, int number, StatusModel.Status walletStatus, List<AccountModel> accounts, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatus = walletStatus;
            Accounts = accounts;
            IsVerified = isVerified;
        }
    }
}
