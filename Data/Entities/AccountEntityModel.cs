using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace Data.Entities
{
    [Table("Account")]
    public class AccountEntityModel : IBaseHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IBAN { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column("CurrencyId")]
        [ForeignKey("CurrencyRelation")]
        public int CurrencyId { get; set; }
        public CurrencyEntityModel CurrencyRelation { get; set; }

        [ForeignKey("Status")]
        [Column("StatusId")]
        public int AccountStatusId { get; set; }
        public StatusEntityModel Status { get; set; }

        [ForeignKey("Wallet")]
        [Column("WalletId")]
        public int WalletId { get; set; }
        public WalletEntityModel Wallet { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserEntityModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserEntityModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public AccountEntityModel() { }

    }
}
