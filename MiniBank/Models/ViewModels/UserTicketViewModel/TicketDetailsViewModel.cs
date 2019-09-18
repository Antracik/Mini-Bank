using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Date Requested")]
        public DateTime DateCreated { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayName("Type")]
        public string TicketType { get; set; }

        [DisplayName("Status")]
        public string TicketStatus { get; set; }
    }
}
