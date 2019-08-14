using Shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mini_Bank.Models
{
    public class UserModel : IBaseHistory
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
        ErrorMessage = "Please enter a valid email!")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Password is required!")]
        [StringLength(50, MinimumLength = 8, ErrorMessage ="Password must be AT LEAST 8 characters long")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
        ErrorMessage = "Passwords must be at least 8 characters and contain 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Admin Rights")]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        public RegistrantModel Registrant { get; set; }

        public int CreatedById { get; set; } = 1;
        public UserModel CreatedByUser { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int? EditedById { get; set; }
        public UserModel EditedByUserId { get; set; }
        public DateTime? DateEdited { get; set; }

        public UserModel(int id, string email, string password, RegistrantModel registrant, bool isAdmin = false)
        {
            Id = id;
            Email = email;
            Password = password;
            Registrant = registrant;
            IsAdmin = isAdmin;
        }

        public UserModel()
        {
                
        }
    }
}
