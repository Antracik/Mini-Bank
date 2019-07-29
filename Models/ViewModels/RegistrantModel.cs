using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using System.ComponentModel;

namespace Mini_Bank.Models
{
    public class RegistrantModel : IBaseModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public List<WalletModel> Wallets { get; set; }

        public RegistrantModel(int id, string firstName, string lastName, string country, string address, List<WalletModel> wallets)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Address = address;
            Wallets = wallets;
        }

        public RegistrantModel()
        {
        }
    }
    
}
