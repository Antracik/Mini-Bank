using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.SharedViewModels
{
    public class CountryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
