using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
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
}
