using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Shared;

namespace FileRepo.Models
{
    [Obsolete]
    [DataContract]
    public class AccountRepoModel : IBaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string IBAN { get; set; }

        [DataMember]
        [DefaultValue(0.00)]
        public decimal Balance { get; set; }

        [DefaultValue(CurrencyEnum.Currency.BGN)]
        [DataMember]
        public CurrencyEnum.Currency Currency{ get; set; }

        [DataMember]
        [DisplayName("Account Status")]
        [DefaultValue(StatusEnum.Status.Okay)]
        public StatusEnum.Status AccountStatus{ get; set; }

        //RELATION
        [DataMember]
        public int WalletId { get; set; }

        [DataMember]
        public int? CreatedById { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set ; }

        [DataMember]
        public int? EditedById { get; set; }

        [DataMember]
        public DateTime? DateEdited { get; set; }

        public AccountRepoModel(int id, string iBAN, decimal balance, int walletId, CurrencyEnum.Currency currency, StatusEnum.Status accountStatus)
        {
            Id = id;
            IBAN = iBAN;
            Balance = balance;
            WalletId = walletId;
            Currency = currency;
            AccountStatus = accountStatus;
        }

        public AccountRepoModel() { }

    }
}
