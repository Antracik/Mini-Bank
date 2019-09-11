using Mini_Bank.Models.ViewModels.SharedViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Mini_Bank.Models.ViewModels
{
    public class RegistrantDetailsViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Country")]
        public CountryModel Country { get; set; }

        public string Address { get; set; }

        public List<WalletModel> Wallets { get; set; }

        [DisplayName("User ID")]
        public int UserId { get; set; }

        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        public RegistrantDetailsViewModel() { }
    }
}
