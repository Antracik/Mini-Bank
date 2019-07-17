using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RegistrantModel Registrant{ get; set; }
        public bool IsAdmin { get; set; }

        public UserModel(int id, string email, string password, RegistrantModel registrant, bool isAdmin = false)
        {
            Id = id;
            Email = email;
            Password = password;
            Registrant = registrant;
            IsAdmin = isAdmin;
        }
    }
}
