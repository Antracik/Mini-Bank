using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface ITicketService
    {
        int CreateTicket(TicketServiceModel ticket);
        TicketServiceModel GetTicketById(int id);
        IEnumerable<TicketServiceModel> GetAllTickets();
    }
}
