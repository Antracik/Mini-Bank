using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class TicketMessageServiceModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public int TicketId { get; set; }
        public TicketServiceModel Ticket { get; set; }

        public int? CreatedById { get; set; }
        public UserServiceModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        public int? EditedById { get; set; }
        public UserServiceModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
