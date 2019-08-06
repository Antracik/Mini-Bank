using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mini_Bank.Models.EnumModels;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.DbRepo.Entities
{
    [Table("Account")]
    public class AccountDbRepoModel : IBaseModel
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
        public CurrencyModel CurrencyRelation { get; set; }

        [ForeignKey("Status")]
        [Column("StatusId")]
        public int AccountStatusId { get; set; }
        public StatusModel Status { get; set; }

        [ForeignKey("Wallet")]
        public int WalletId { get; set; }
        public WalletDbRepoModel Wallet { get; set; }

        public AccountDbRepoModel() { }

    }
}
