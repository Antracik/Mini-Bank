using Mini_Bank.Models.ViewModels.SharedViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class VerifyWalletAccounts
    {
        [Display(Name = "Account Id")]
        public int Id { get; set; }

        [Required]
        public string IBAN { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public CurrencyModel Currency { get; set; }
    }
}
