using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Shared;

namespace FileRepo.Models
{
    [DataContract]
    public class WalletRepoModel : IBaseModel
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Number { get; set; }

        [DataMember]
        [DisplayName("Wallet Status")]
        public StatusEnum.Status WalletStatus { get; set; }

        [DataMember]
        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        //Relation
        [DataMember]
        public int RegistrantId { get; set; }

        public WalletRepoModel(int id, int number, StatusEnum.Status walletStatus, int registrantId, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatus = walletStatus;
            IsVerified = isVerified;
            RegistrantId = registrantId;
        }

        public WalletRepoModel() { }

    }

    public static class WalletEextension
    {
        public static IEnumerable<AccountRepoModel> GetWalletAccounts(this WalletRepoModel source, IRepository<AccountRepoModel> repository)
        {
            return from accounts in repository.Get()
                   where accounts.WalletId == source.Id
                   select accounts;
        }
    }

}
