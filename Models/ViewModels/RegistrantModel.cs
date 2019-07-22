﻿using System.Collections.Generic;

namespace Mini_Bank.Models
{
    public class RegistrantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        //RELATION
        public int UserId { get; set; }

        public RegistrantModel(int id, string name, string country, string address, int userId)
        {
            Id = id;
            Name = name;
            Country = country;
            Address = address;
            UserId = userId;
        }

        //FOR LATER USE
        //public List<WalletModel> Wallets{ get; set; }

        //public RegistrantModel(int id, string name, string country, string address, List<WalletModel> wallets)
        //{
        //    Id = id;
        //    Name = name;
        //    Country = country;
        //    Address = address;
        //    Wallets = wallets;
        //}


    }
}