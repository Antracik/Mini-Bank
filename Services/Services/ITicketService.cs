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
        TicketServiceModel GetTicket(int userId, int ticketId);
        IEnumerable<TicketServiceModel> GetAllTickets();
    }
}
