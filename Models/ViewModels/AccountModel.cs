using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [Required]
        [DefaultValue(CurrencyModel.Currency.BGN)]
        public CurrencyModel.Currency Currency{ get; set; }
        public int WalletId { get; set; }

        [Required]
        [DefaultValue(StatusModel.Status.Okay)]
        [DisplayName("Account Status")]
        public StatusModel.Status AccountStatus{ get; set; }

        public AccountModel() { }
    }
}
