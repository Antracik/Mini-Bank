using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    //ASK for better option(?)
    public class UserWalletsViewModel
    {

        public List<UserWallets> Wallets { get; set; }
        public UserWalletTransaction InputTransaction { get; set; }

        public class UserWallets
        {
            public List<UserWalletAccounts> Accounts { get; set; }

            [Display(Name = "Wallet number")]
            public int Number { get; set; }
            public string Verified { get; set; }
            public DateTime DateCreated { get; set; }

            //For accordion
            public string Heading { get; set; }
            public string RowId { get; set; }
        }

        public class UserWalletAccounts
        {
            public int Id { get; set; }
            public string IBAN { get; set; }

            public decimal Balance { get; set; }

            public string Currency { get; set; }
        }

        public class UserWalletTransaction
        {
            [Required]
            [Display(Name = "IBAN to send to")]
            public string ToIBAN { get; set; }

            //REMOVE once we have ensured IBAN uniqueness
            [Required]
            public int FromAccountWithId { get; set; }

            //[Required]
            //public string FromIBAN { get; set; }

            [Required]
            [Display(Name = "Amount to send")]
            [Range(typeof(decimal),"1","10000000000",ErrorMessage = "Amount to send must be higher than 0")]
            public decimal Amount { get; set; }
        }

    }

}
