
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models.EnumModels
{
    [Table("Currency")]
    public class CurrencyModel
    {
        public enum Currency
        {
            BGN,
            USD,
            GBP
        }

        [Column(TypeName = "int")]
        public Currency Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public Currency Name { get; set; }
    }
}
