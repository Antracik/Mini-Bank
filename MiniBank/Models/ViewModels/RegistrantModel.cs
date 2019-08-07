﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shared;

namespace Mini_Bank.Models
{
    public class RegistrantModel : IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name cannot be empty!")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Only letters and no whitespaces!")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name cannot be empty!")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Only letters and no whitespaces!")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Country cannot be empty")]
        [DisplayName("Country")]
        public int CountryId { get; set; }
        public CountryModel CountryModel { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Address cannot be empty")]
        [MinLength(1, ErrorMessage = "Address cannot be empty!")]
        public string Address { get; set; }
        public List<WalletModel> Wallets { get; set; }

        public int UserId { get; set; }

        public RegistrantModel(int id, string firstName, string lastName, int countryId, string address, List<WalletModel> wallets)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CountryId = countryId;
            Address = address;
            Wallets = wallets;
        }

        public RegistrantModel() { }
    }
    
}