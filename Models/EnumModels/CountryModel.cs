using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.EnumModels
{
    [Table("Country")]
    public class CountryModel
    {

        public enum Countries
        {
            Bulgaria = 1,
            Romania,
            Germany,
            Greece,
            England,
            France,
            Italy
        }

        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }
    }
}
