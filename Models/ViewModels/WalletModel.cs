using Mini_Bank.Models.EnumModels;
using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models
{
    public class WalletModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Number is required!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only positive numbers!")]
        public int Number { get; set; }

        [DisplayName("Wallet Status")]
        [DefaultValue(StatusModel.Status.Okay)]
        public StatusModel.Status WalletStatus { get; set; }

        [Required]
        [DefaultValue(false)]
        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        public int RegistrantId { get; set; }

        public List<AccountModel> Accounts { get; set; }

        public WalletModel(int id, int number, StatusModel.Status walletStatus, List<AccountModel> accounts, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatus = walletStatus;
            Accounts = accounts;
            IsVerified = isVerified;
        }

        public WalletModel()
        {

        }
    }
}
