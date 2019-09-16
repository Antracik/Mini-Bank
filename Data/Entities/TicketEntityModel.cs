using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Tickets")]
    public class TicketEntityModel : IBaseHistory
    {
        public int Id { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserEntityModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("TicketType")]
        public int TicketTypeId { get; set; }
        public TicketTypeEntityModel TicketType { get; set; }

        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(500)]
        [Required]
        public string Description { get; set; }

        [ForeignKey("TicketStatus")]
        public int TicketStatusId { get; set; }
        public TicketStatusEntityModel TicketStatus { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserEntityModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public IEnumerable<TicketMessageEntityModel> MessageHistory { get; set; }
    }
}
