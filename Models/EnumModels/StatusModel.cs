
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models.EnumModels
{
    [Table("Status")]
    public class StatusModel
    {
        public enum Status
        {
            Okay,
            Blocked
        }

        [Column(TypeName = "int")]
        public Status Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public Status Name { get; set; }

    }
}
