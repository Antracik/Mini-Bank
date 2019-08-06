﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mini_Bank.Models.EnumModels;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.Models
{
    public class AccountModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "IBAN can't be empty")]
        [RegularExpression(@"^([A-Z]{2}[ \-]?[0-9]{2})(?=(?:[ \-]?[A-Z0-9]){9,30}$)((?:[ \-]?[A-Z0-9]{3,5}){2,7})([ \-]?[A-Z0-9]{1,3})?$",
                            ErrorMessage = "Invalid IBAN")]
        public string IBAN { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Balance { get; set; }

        [Required]
        [DisplayName("Currency")]
        public int CurrencyId { get; set; } = (int)CurrencyModel.Currency.BGN;
        public CurrencyModel Currency{ get; set; }

        public int WalletId { get; set; }

        [Required]
        [DisplayName("Account Status")]
        public int AccountStatusId { get; set; } = (int)StatusModel.Status.Okay;
        public StatusModel Status { get; set; }

        public AccountModel() { }
    }
}
