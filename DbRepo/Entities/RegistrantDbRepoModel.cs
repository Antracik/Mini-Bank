using Mini_Bank.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mini_Bank.Models.EnumModels;

namespace Mini_Bank.DbRepo.Entities
{
    [Table("Registrant")]
    public class RegistrantDbRepoModel : IBaseModel
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
        public CountryModel CountryRelation { get; set; }

        [Required]
        public string Address { get; set; }

        //RELATION
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserDbRepoModel User { get; set; }

        public RegistrantDbRepoModel(int id, string firstName, string lastName, int countryId, string address, int userId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = countryId;
            Address = address;
            UserId = userId;
        }

        public RegistrantDbRepoModel() {}
    }
}
