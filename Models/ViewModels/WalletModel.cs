using System.Collections.Generic;
using System.ComponentModel;

namespace Mini_Bank.Models
{
    public class WalletModel
    {
        public int Id { get; set; }
        public int Number { get; set; }

        [DisplayName("Wallet Status")]
        public StatusModel.Status WalletStatus { get; set; }

        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        //Relation
        public int ReginstrantId { get; set; }

        public WalletModel(int id, int number, StatusModel.Status walletStatus, int reginstrantId, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatus = walletStatus;
            IsVerified = isVerified;
            ReginstrantId = reginstrantId;
        }

        // FOR LATER USE
        //public List<AccountModel> Accounts { get; set; }
        
        //FOR LATER USE
        //public WalletModel(int id, int number, StatusModel.Status walletStatus, List<AccountModel> accounts, bool isVerified = false)
        //{
        //    Id = id;
        //    Number = number;
        //    WalletStatus = walletStatus;
        //    Accounts = accounts;
        //    IsVerified = isVerified;
        //}
    }
}
