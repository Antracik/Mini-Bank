using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.Models 
{
    public class AccountModel : IBaseModel
    {
        public int Id { get; set; }
        public string IBAN { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public CurrencyModel.Currency Currency{ get; set; }

        [DisplayName("Account Status")]
        public StatusModel.Status AccountStatus{ get; set; }

        public AccountModel()
        {

        }
    }
}
