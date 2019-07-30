using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mini_Bank.Models
{
    public class RegistrantModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name can't be empty!")]
        [RegularExpression(@"/\s/", ErrorMessage = "Remove Whitespaces")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name can't be empty!")]
        [RegularExpression(@"/\s/", ErrorMessage = "Remove Whitespaces")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Country can't be empty")]
        [MinLength(1, ErrorMessage ="Country can't be empty!")]
        [RegularExpression(@"^\s*$", ErrorMessage = "Country can't be empty!")]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address can't be empty")]
        [MinLength(1, ErrorMessage = "Address can't be empty!")]
        [RegularExpression(@"^\s*$", ErrorMessage = "Address can't be empty!")]
        public string Address { get; set; }
        public List<WalletModel> Wallets { get; set; }

        public int UserId { get; set; }

        public RegistrantModel(int id, string firstName, string lastName, string country, string address, List<WalletModel> wallets)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Address = address;
            Wallets = wallets;
        }

        public RegistrantModel() { }
    }
    
}
