using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.FileRepo.Models
{
    [DataContract]
    public class AccountRepoModel : IBaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IBAN { get; set; }

        [DataMember]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        [DataMember]
        public CurrencyModel.Currency Currency{ get; set; }

        [DataMember]
        [DisplayName("Account Status")]
        public StatusModel.Status AccountStatus{ get; set; }

        //RELATION
        [DataMember]
        public int WalletId { get; set; }

        public AccountRepoModel(int id, string iBAN, decimal balance, int walletId, CurrencyModel.Currency currency, StatusModel.Status accountStatus)
        {
            Id = id;
            IBAN = iBAN;
            Balance = balance;
            WalletId = walletId;
            Currency = currency;
            AccountStatus = accountStatus;
        }

        public AccountRepoModel() { }

    }
}
