using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("TicketType")]
    public class TicketTypeEntityModel : IBaseModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
