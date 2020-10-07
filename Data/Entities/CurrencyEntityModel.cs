
using Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Currency")]
    public class CurrencyEntityModel : IBaseModel
    {
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
        
    }
}
