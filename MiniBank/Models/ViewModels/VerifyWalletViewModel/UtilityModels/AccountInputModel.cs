using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class AccountInputModel
    {
        [Required]
        public string IBAN { get; set; }
        
        [Required]
        public decimal Balance { get; set; }

        [Display(Name = "Country")]
        [Required]
        public int CurrencyId { get; set; }
    }
}
