using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;
using System;

namespace Data.Entities
{
    [Table("Wallet")]
    public class WalletEntityModel : IBaseHistory
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        [Column("WalletStatusId")]
        [ForeignKey("Status")]
        public int WalletStatusId { get; set; }
        public StatusEntityModel Status { get; set; }

        public bool IsVerified { get; set; }

        //Relation
        [ForeignKey("Registrant")]
        public int RegistrantId { get; set; }
        public RegistrantEntityModel Registrant { get; set; }

        public List<AccountEntityModel> Accounts { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserEntityModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserEntityModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public WalletEntityModel() { }

    }

}
