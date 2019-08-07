using Shared;
using System.Collections.Generic;

namespace Services.Models
{
    public class WalletServiceModel : IBaseModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int WalletStatusId { get; set; }
        public StatusServiceModel Status { get; set; }

        public bool IsVerified { get; set; }

        public int RegistrantId { get; set; }
        public RegistrantServiceModel Registrant { get; set; }

        public List<AccountServiceModel> Accounts { get; set; }

        public WalletServiceModel() { }

    }

}
