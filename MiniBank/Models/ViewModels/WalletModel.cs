using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mini_Bank.Models
{
    public class WalletModel : IBaseHistory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Number is required!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only positive numbers!")]
        public int Number { get; set; }

        [DisplayName("Wallet Status")]
        public int WalletStatusId { get; set; } = (int)StatusEnum.Status.Okay;
        public StatusModel Status { get; set; }

        [Required]
        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        public int RegistrantId { get; set; }

        public List<AccountModel> Accounts { get; set; }

        public int CreatedById { get; set; } = 1;
        public UserModel CreatedByUser { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int? EditedById { get; set; }
        public UserModel EditedByUserId { get; set; }
        public DateTime? DateEdited { get; set; }

        public WalletModel(int id, int number, int walletStatusId, List<AccountModel> accounts, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatusId = walletStatusId;
            Accounts = accounts;
            IsVerified = isVerified;
        }

        public WalletModel()
        {

        }
    }
}
