using Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.Models
{
    public class StatusModel : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
