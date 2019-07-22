﻿using System.ComponentModel;

namespace Mini_Bank.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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