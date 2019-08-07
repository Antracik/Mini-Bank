﻿using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Shared;

namespace Mini_Bank.FileRepo.Models
{
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
        [DisplayName("Admin")]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        public UserRepoModel(int id, string email, string password, bool isAdmin = false)
        {
            Id = id;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }

        public UserRepoModel() { }

    }

    public static class UserExtension
    {
        public static RegistrantRepoModel GetRegistrant(this UserRepoModel source, IRepository<RegistrantRepoModel> repository)
        {
            return repository.Get().FirstOrDefault(reg => reg.UserId == source.Id);
        }
    }
}