using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shared;

namespace Mini_Bank.Models
{
    public class AccountModel : IBaseHistory
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
        public int CurrencyId { get; set; } = (int)CurrencyEnum.Currency.BGN;
        public CurrencyModel Currency{ get; set; }

        public int WalletId { get; set; }

        [Required]
        [DisplayName("Account Status")]
        public int AccountStatusId { get; set; } = (int)StatusEnum.Status.Okay;

        public StatusModel Status { get; set; }

        public int? CreatedById { get; set; }
        public UserModel CreatedByUser { get; set; }

        public DateTime DateCreated { get; set; }

        public int? EditedById { get; set; }
        public UserModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public AccountModel() { }
    }
}
