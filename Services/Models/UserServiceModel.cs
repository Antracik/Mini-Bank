using Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class UserServiceModel : IBaseModel
    {
        public int Id { get; set; }

        public string Email { get;  set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public RegistrantServiceModel Registrant { get; set; }

        public UserServiceModel() { }

    }
}
