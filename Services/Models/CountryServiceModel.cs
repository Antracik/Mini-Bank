using Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Models
{
    public class CountryServiceModel : IBaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
