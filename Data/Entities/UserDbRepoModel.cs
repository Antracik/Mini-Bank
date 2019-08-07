﻿using Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{ 
    [Table("User")]
    public class UserDbRepoModel : IBaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get;  set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }

        public RegistrantDbRepoModel Registrant { get; set; }

        public UserDbRepoModel() { }

    }
}