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
        [RegularExpression(@"/^(?:(?:IT|SM)\d{2}[A-Z]\d{22}|CY\d{2}[A-Z]\d{23}|NL\d{2}[A-Z]{4}\d{10}|LV\d{2}[A-Z]{4}\d{13}|(?:BG|BH|GB|IE)\d{2}[A-Z]{4}\d{14}|GI\d{2}[A-Z]{4}\d{15}|RO\d{2}[A-Z]{4}\d{16}|KW\d{2}[A-Z]{4}\d{22}|MT\d{2}[A-Z]{4}\d{23}|NO\d{13}|(?:DK|FI|GL|FO)\d{16}|MK\d{17}|(?:AT|EE|KZ|LU|XK)\d{18}|(?:BA|HR|LI|CH|CR)\d{19}|(?:GE|DE|LT|ME|RS)\d{20}|IL\d{21}|(?:AD|CZ|ES|MD|SA)\d{22}|PT\d{23}|(?:BE|IS)\d{24}|(?:FR|MR|MC)\d{25}|(?:AL|DO|LB|PL)\d{26}|(?:AZ|HU)\d{27}|(?:GR|MU)\d{28})$/i",
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
