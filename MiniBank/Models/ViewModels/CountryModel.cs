using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models
{
    public class CountryModel : IBaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
