using Mini_Bank.Models.ViewModels.SharedViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels.UtilityModels
{
    public class UserTicketViewModel
    {
        [DisplayName("Date Requested")]
        public DateTime DateCreated { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [DisplayName("Ticket Type")]
        public TicketTypeViewModel TicketType { get; set; }

        [DisplayName("Status")]
        public TicketStatusViewModel TicketStatus { get; set; }
    }
}
