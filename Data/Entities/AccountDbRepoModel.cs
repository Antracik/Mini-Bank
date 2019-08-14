using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace Data.Entities
{
    [Table("Account")]
    public class AccountDbRepoModel : IBaseHistory
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
        public CurrencyDbRepoModel CurrencyRelation { get; set; }

        [ForeignKey("Status")]
        [Column("StatusId")]
        public int AccountStatusId { get; set; }
        public StatusDbRepoModel Status { get; set; }

        [ForeignKey("Wallet")]
        public int WalletId { get; set; }
        public WalletDbRepoModel Wallet { get; set; }

        [ForeignKey("CreatedByUser")]
        public int CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public AccountDbRepoModel() { }

    }
}
