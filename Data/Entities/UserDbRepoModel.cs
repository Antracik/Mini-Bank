using Microsoft.AspNetCore.Identity;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{ 
    [Table("User")]
    public class UserDbRepoModel : IdentityUser<int>, IBaseHistory
    {
        [InverseProperty("User")]
        public RegistrantDbRepoModel Registrant { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public UserDbRepoModel() { }

    }
}
