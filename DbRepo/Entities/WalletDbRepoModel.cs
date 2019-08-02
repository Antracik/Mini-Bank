﻿using Mini_Bank.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mini_Bank.Models.EnumModels;

namespace Mini_Bank.DbRepo.Entities
{
    [Table("Wallet")]
    public class WalletDbRepoModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        [Column("WalletStatusId")]
        [ForeignKey("Status")]
        public int WalletStatus { get; set; }
        public StatusModel Status { get; set; }

        public bool IsVerified { get; set; }

        //Relation
        [ForeignKey("Registrant")]
        public int RegistrantId { get; set; }
        public RegistrantDbRepoModel Registrant { get; set; }

        public WalletDbRepoModel(int id, int number, int walletStatus, int registrantId, bool isVerified = false)
        {
            Id = id;
            Number = number;
            WalletStatus = walletStatus;
            IsVerified = isVerified;
            RegistrantId = registrantId;
        }

        public WalletDbRepoModel() { }

    }

}
