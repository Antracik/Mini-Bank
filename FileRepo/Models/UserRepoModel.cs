using Mini_Bank.Models.ViewModels;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Linq;

namespace Mini_Bank.FileRepo.Models
{ 
    [DataContract]
    public class UserRepoModel : IBaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }

        public UserRepoModel(int id, string email, string password, bool isAdmin = false)
        {
            Id = id;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }

    }

    public static class UserExtension
    {
        public static RegistrantRepoModel GetRegistrant(this UserRepoModel source, IRepository<RegistrantRepoModel> repository)
        {
            return repository.Get().FirstOrDefault(reg => reg.UserId == source.Id);
        }
    }
}
