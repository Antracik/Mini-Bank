using Shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{ 
    [Table("User")]
    public class UserDbRepoModel : IBaseHistory
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

        [NotMapped]
        public RegistrantDbRepoModel Registrant { get; set; }

        [ForeignKey("CreatedByUser")]
        public int CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public UserDbRepoModel() { }

    }
}
