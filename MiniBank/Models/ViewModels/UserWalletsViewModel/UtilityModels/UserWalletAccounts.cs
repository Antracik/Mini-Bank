using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class UserWalletAccounts
    {
        public int Id { get; set; }
        public string IBAN { get; set; }

        public decimal Balance { get; set; }

        public string Currency { get; set; }
    }
}
