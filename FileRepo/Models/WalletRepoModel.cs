using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Shared;
using System;

namespace FileRepo.Models
{
    [Obsolete]
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

        [DataMember]
        public int? CreatedById { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public int? EditedById { get; set; }

        [DataMember]
        public DateTime? DateEdited { get; set; }

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

}
