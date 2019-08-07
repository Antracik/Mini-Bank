using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace Services.Models
{
    public class AccountServiceModel : IBaseModel
    {
        public int Id { get; set; }

        public string IBAN { get; set; }

        public decimal Balance { get; set; }

        public int CurrencyId { get; set; }
        public CurrencyServiceModel CurrencyRelation { get; set; }

        public int AccountStatusId { get; set; }
        public StatusServiceModel Status { get; set; }

        public int WalletId { get; set; }
        public WalletServiceModel Wallet { get; set; }

        public AccountServiceModel() { }

    }
}
