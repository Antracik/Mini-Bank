using Mini_Bank.Models.ViewModels.SharedViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class TicketViewModel
    {
        public string Message { get; set; }

        public List<UserTicketViewModel> UserTickets { get; set; }

        public List<TicketTypeViewModel> TicketTypes { get; set; }

        public TicketRequestViewModel TicketRequest { get; set; }
    }
}
