using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.SharedViewModels
{ 
    public class TransactionViewModel
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
        [Range(typeof(decimal), "1", "10000000000", ErrorMessage = "Amount to send must be higher than 0")]
        public decimal Amount { get; set; }
    }
}
