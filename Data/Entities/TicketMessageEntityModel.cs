using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("TicketMessages")]
    public class TicketMessageEntityModel : IBaseHistory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public TicketEntityModel Ticket { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserEntityModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserEntityModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
