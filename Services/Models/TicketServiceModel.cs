using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class TicketServiceModel
    {
        public int Id { get; set; }

        public int? CreatedById { get; set; }
        public UserServiceModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        public int TicketTypeId { get; set; }
        public TicketTypeServiceModel TicketType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TicketStatusId { get; set; }
        public TicketStatusServiceModel TicketStatus { get; set; }

        public int? EditedById { get; set; }
        public UserServiceModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }

        public IEnumerable<TicketMessageServiceModel> MessageHistory { get; set; }
    }
}
