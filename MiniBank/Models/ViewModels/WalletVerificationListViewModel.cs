using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class WalletVerificationListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Wallet Number")]
        public int Number { get; set; }

        [Display(Name = "Created by Id")]
        public int? CreatedById { get; set; }

        [Display(Name = "Registrant Id")]
        public int RegistrantId { get; set; }

        [Display(Name ="Date Requested")]
        public DateTime DateCreated { get; set; }
    }
}
