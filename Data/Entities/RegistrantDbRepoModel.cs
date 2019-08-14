﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;
using System;

namespace Data.Entities
{
    [Table("Registrant")]
    public class RegistrantDbRepoModel : IBaseHistory
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
        public CountryDbRepoModel CountryRelation { get; set; }

        [Required]
        public string Address { get; set; }

        //RELATION
        [ForeignKey("User")]
        [Column("UserId")]
        public int UserId { get; set; }
        public UserDbRepoModel User { get; set; }

        public List<WalletDbRepoModel> Wallets { get; set; }

        [ForeignKey("CreatedByUser")]
        public int CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public RegistrantDbRepoModel() {}
    }
}
