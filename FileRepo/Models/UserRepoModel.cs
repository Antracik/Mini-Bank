using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Shared;
using System;

namespace FileRepo.Models
{
    [Obsolete]
    [DataContract]
    public class UserRepoModel : IBaseModel
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [DataMember]
        [MaxLength(50)]
        public string Password { get; set; }

        [DataMember]
        public int? CreatedById { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public int? EditedById { get; set; }

        [DataMember]
        public DateTime? DateEdited { get; set; }

        public UserRepoModel(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public UserRepoModel() { }

    }
   
}
