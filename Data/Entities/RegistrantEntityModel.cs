using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;
using System;

namespace Data.Entities
{
    [Table("Registrant")]
    public class RegistrantEntityModel : IBaseHistory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [ForeignKey("CountryRelation")]
        [Column("CountryId")]
        public int Country { get; set; }
        public CountryEntityModel CountryRelation { get; set; }

        [Required]
        public string Address { get; set; }

        //RELATION
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntityModel User { get; set; }

        public List<WalletEntityModel> Wallets { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserEntityModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserEntityModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public RegistrantEntityModel() {}
    }
}
