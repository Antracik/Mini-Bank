using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{ 
    [Table("User")]
    public class UserDbRepoModel : IBaseHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get;  set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }

        [InverseProperty("User")]
        public RegistrantDbRepoModel Registrant { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        //public UserDbRepoModel Creator { get; set; }
        //public UserDbRepoModel Editor { get; set; }

        public UserDbRepoModel() { }

    }
}
