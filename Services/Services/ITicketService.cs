using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface ITicketService
    {
        void MarkAsClosed(int ticketId);
        int CreateTicket(TicketServiceModel ticket);
        int CreateMessage(TicketMessageServiceModel message);
        TicketServiceModel GetTicketById(int id, bool includeCreatedBy = false);
        TicketServiceModel GetTicket(int userId, int ticketId);
        IEnumerable<TicketMessageServiceModel> GetMessages();
        IEnumerable<TicketMessageServiceModel> GetMessages(int pageIndex, int pageSize, bool includeCreatedBy = false);
        IEnumerable<TicketMessageServiceModel> GetMessages(int ticketId, int pageIndex, int pageSize, bool includeCreatedBy = false);
        IEnumerable<TicketServiceModel> GetAllTicketsForUser(int userId);
        IEnumerable<TicketServiceModel> GetAllTickets();
    }
}
