using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mini_Bank.Models
{
    [DataContract]
    public class WalletModel : IBaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
        [DisplayName("Wallet Status")]
        public StatusModel.Status WalletStatus { get; set; }

        [DataMember]
        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        //Relation
        [DataMember]
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
