
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models.EnumModels
{
    [Table("Currency")]
    public class CurrencyModel
    {
        public enum Currency
        {
            BGN = 1,
            USD,
            GBP
        }

        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
    }
}
