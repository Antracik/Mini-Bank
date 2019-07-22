using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mini_Bank.Models
{
    [DataContract]
    public class UserModel
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

        public UserModel(int id, string email, string password, bool isAdmin = false)
        {
            Id = id;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }


        //FOR LATER USE
        //public RegistrantModel Registrant{ get; set; }
        //public UserModel(int id, string email, string password, RegistrantModel registrant, bool isAdmin = false)
        //{
        //    Id = id;
        //    Email = email;
        //    Password = password;
        //    Registrant = registrant;
        //    IsAdmin = isAdmin;
        //}
    }
}
