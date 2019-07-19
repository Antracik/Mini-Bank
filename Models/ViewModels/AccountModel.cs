using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mini_Bank.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string IBAN { get; set; }

        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public CurrencyModel.Currency Currency{ get; set; }

        [DisplayName("Account Status")]
        public StatusModel.Status AccountStatus{ get; set; }

        public AccountModel(int id, string iBAN, decimal balance, CurrencyModel.Currency currency, StatusModel.Status accountStatus)
        {
            Id = id;
            IBAN = iBAN;
            Balance = balance;
            Currency = currency;
            AccountStatus = accountStatus;
        }

    }
}
