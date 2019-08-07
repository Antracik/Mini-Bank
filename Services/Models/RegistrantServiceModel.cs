using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;

namespace Services.Models
{
    public class RegistrantServiceModel : IBaseModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Country { get; set; }
        public CountryServiceModel CountryRelation { get; set; }

        public string Address { get; set; }

        public int UserId { get; set; }
        public UserServiceModel User { get; set; }

        public List<WalletServiceModel> Wallets { get; set; }

        public RegistrantServiceModel() {}
    }
}
