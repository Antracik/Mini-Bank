using Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Status")]
    public class StatusDbRepoModel : IBaseModel
    {
        public static object Status { get; internal set; }

        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }
    }
}
