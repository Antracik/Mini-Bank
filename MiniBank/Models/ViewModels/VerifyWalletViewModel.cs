using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class VerifyWalletViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Wallet Number")]
        public int Number { get; set; }

        [Display(Name = "Created by Id")]
        public int? CreatedById { get; set; }

        [Display(Name = "Registrant Id")]
        public int RegistrantId { get; set; }

        [Display(Name = "Date Requested")]
        public DateTime DateCreated { get; set; }

        public List<CurrencyModel> CurrencyList { get; set; }

        public VerifyWalletAccounts Account { get; set; }

        public List<VerifyWalletAccounts> Accounts { get; set; }
    }

    public class VerifyWalletAccounts
    {
        [Display(Name = "Account Id")]
        public int Id { get; set; }

        [Required]
        public string IBAN { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        public string Currency { get; set; }

    }
}
