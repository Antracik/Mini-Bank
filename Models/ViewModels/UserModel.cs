using Mini_Bank.Models.ViewModels;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mini_Bank.Models
{
    public class UserModel : IBaseModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [DisplayName("Admin Rights")]
        public bool IsAdmin { get; set; }
        public RegistrantModel Registrant { get; set; }

        public UserModel(int id, string email, string password, RegistrantModel registrant, bool isAdmin = false)
        {
            Id = id;
            Email = email;
            Password = password;
            Registrant = registrant;
            IsAdmin = isAdmin;
        }

        public UserModel()
        {
                
        }
    }
}
