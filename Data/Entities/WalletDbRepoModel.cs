using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;
using System;

namespace Data.Entities
{
    [Table("Wallet")]
    public class WalletDbRepoModel : IBaseHistory
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

        [ForeignKey("CreatedByUser")]
        public int CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public WalletDbRepoModel() { }

    }

}
