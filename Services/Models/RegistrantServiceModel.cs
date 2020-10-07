using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Shared;
using System;

namespace Services.Models
{
    public class RegistrantServiceModel : IBaseHistory
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

        public int? CreatedById { get; set; }
        public UserServiceModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        public int? EditedById { get; set; }
        public UserServiceModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public RegistrantServiceModel() {}
    }
}
