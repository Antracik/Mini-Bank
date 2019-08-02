
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models.EnumModels
{
    [Table("Status")]
    public class StatusModel
    {
        public enum Status
        {
            Okay = 1,
            Blocked
        }

        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
    }
}
