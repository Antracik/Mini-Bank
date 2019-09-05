using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class UserWalletsViewModel
    {
        public List<UserWalletAccounts> Accounts { get; set; }

        [Display( Name = "Wallet number")]
        public int Number { get; set; }
        public string Verified { get; set; }
        public DateTime DateCreated { get; set; }

        public string Heading { get; set; }
        public string RowId { get; set; }
    }

    public class UserWalletAccounts
    {
        public string IBAN { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }
    }

    public class UserWalletTransaction
    {
        [Required]
        public string ToIBAN { get; set; }

        [Required]
        public string FromIBAN { get; set; }

        [Required]
        public decimal Amount{ get; set; }
    }

}
