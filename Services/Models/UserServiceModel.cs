using Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class UserServiceModel : IBaseHistory
    {
        public int Id { get; set; }

        public string Email { get;  set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public RegistrantServiceModel Registrant { get; set; }

        public int? CreatedById { get; set; }
        public UserServiceModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        public int? EditedById { get; set; }
        public UserServiceModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public UserServiceModel() { }

    }
}
