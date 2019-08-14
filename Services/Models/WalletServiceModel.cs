using Shared;
using System;
using System.Collections.Generic;

namespace Services.Models
{
    public class WalletServiceModel : IBaseHistory
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int WalletStatusId { get; set; }
        public StatusServiceModel Status { get; set; }

        public bool IsVerified { get; set; }

        public int RegistrantId { get; set; }
        public RegistrantServiceModel Registrant { get; set; }

        public List<AccountServiceModel> Accounts { get; set; }

        public int CreatedById { get; set; }
        public UserServiceModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        public int? EditedById { get; set; }
        public UserServiceModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public WalletServiceModel() { }

    }

}
