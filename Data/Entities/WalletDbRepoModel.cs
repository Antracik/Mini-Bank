using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;

namespace Data.Entities
{
    [Table("Wallet")]
    public class WalletDbRepoModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        [Column("WalletStatusId")]
        [ForeignKey("Status")]
        public int WalletStatusId { get; set; }
        public StatusDbRepoModel Status { get; set; }

        public bool IsVerified { get; set; }

        //Relation
        [ForeignKey("Registrant")]
        public int RegistrantId { get; set; }
        public RegistrantDbRepoModel Registrant { get; set; }

        public List<AccountDbRepoModel> Accounts { get; set; }

        public WalletDbRepoModel() { }

    }

}
