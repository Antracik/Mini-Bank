using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;

namespace Mini_Bank.Models
{
    public class WalletModel : IBaseModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        [DisplayName("Wallet Status")]
        public StatusModel.Status WalletStatus { get; set; }

        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        public List<AccountModel> Accounts { get; set; }

        public WalletModel(int id, int number, StatusModel.Status walletStatus, List<AccountModel> accounts, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatus = walletStatus;
            Accounts = accounts;
            IsVerified = isVerified;
        }

        public WalletModel()
        {

        }
    }
}
