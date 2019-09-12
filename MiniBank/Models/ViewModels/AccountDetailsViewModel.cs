using Mini_Bank.Models.ViewModels.SharedViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        public int Id { get; set; }

        public string IBAN { get; set; }

        public decimal Balance { get; set; }

        public CurrencyModel Currency { get; set; }

        [DisplayName("Account Status")]
        public StatusModel AccountStatus { get; set; }

        public TransactionViewModel InputTransaction { get; set; }

        public string Message { get; set; }
    }
}
