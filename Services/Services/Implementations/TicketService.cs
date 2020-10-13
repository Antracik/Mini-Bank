using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;
using Shared;

namespace Services.Services.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDateService _dateService;



        public TicketService(UnitOfWork unitOfWork,
                                IMapper mapper,
                                IDateService dateService)
        {
            _dateService = dateService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int CreateTicket(TicketServiceModel ticket)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>().GetRepository<TicketEntityModel>();

            var entity = _mapper.Map<TicketEntityModel>(ticket);

            _dateService.SetDateCreatedNow(ref entity);

            entity.TicketType = null;
            entity.TicketStatus = null;

            ticketRepo.AddItem(entity);
            _unitOfWork.Save();

            return entity.Id;
        }

        public int CreateMessage(TicketMessageServiceModel message)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketMessageEntityModel>()
                                        .GetRepository<TicketMessageEntityModel>();

            var entity = _mapper.Map<TicketMessageEntityModel>(message);

            _dateService.SetDateCreatedNow(ref entity);

            ticketRepo.AddItem(entity);
            _unitOfWork.Save();

            return entity.Id;
        }

        public IEnumerable<TicketServiceModel> GetAllTickets()
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>()
                                        .GetRepository<TicketEntityModel>();

            var entities = ticketRepo.Get(includeProperties: "TicketStatus,TicketType");

            var serviceModels = _mapper.Map<List<TicketServiceModel>>(entities);

            return serviceModels;
        }

        public TicketServiceModel GetTicketById(int id, bool includeCreatedBy = false)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>()
                                        .GetRepository<TicketEntityModel>();

            string includes = "TicketStatus,TicketType";

            if(includeCreatedBy)
            {
                includes += ",CreatedByUser";
            }

            var entity = ticketRepo.Get(x => x.Id == id, includeProperties: includes).FirstOrDefault();

            var serviceModel = _mapper.Map<TicketServiceModel>(entity);

            return serviceModel;
        }

        public TicketServiceModel GetTicket(int userId, int ticketId)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>()
                                        .GetRepository<TicketEntityModel>();

            var entity = ticketRepo.Get(x => x.Id == ticketId && x.CreatedById == userId, includeProperties: "TicketStatus,TicketType").FirstOrDefault();

            var serviceModel = _mapper.Map<TicketServiceModel>(entity);

            return serviceModel;
        }

        public IEnumerable<TicketServiceModel> GetAllTicketsForUser(int userId)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>()
                                        .GetRepository<TicketEntityModel>();

            var entities = ticketRepo.Get(x => x.CreatedById == userId, includeProperties: "TicketStatus,TicketType");

            var serviceModels = _mapper.Map<List<TicketServiceModel>>(entities);

            return serviceModels;
        }

        public IEnumerable<TicketMessageServiceModel> GetMessages()
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketMessageEntityModel>()
                                        .GetRepository<TicketMessageEntityModel>();

            var entities = ticketRepo.Get(null, x => x.OrderBy(y => y.DateCreated));

            var serviceModels = _mapper.Map<List<TicketMessageServiceModel>>(entities);

            return serviceModels;
        }

        public IEnumerable<TicketMessageServiceModel> GetMessages(int pageIndex, int pageSize, bool includeCreatedBy = false)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketMessageEntityModel>()
                                        .GetRepository<TicketMessageEntityModel>();

            string includes = "";

            if (includeCreatedBy)
                includes += "CreatedByUser";

            var entities = ticketRepo.Get(null, x => x.OrderBy(y => y.DateCreated))
                                     .Skip(pageIndex * pageSize)
                                     .Take(pageSize);

            var serviceModels = _mapper.Map<List<TicketMessageServiceModel>>(entities);

            return serviceModels;
        }

        public IEnumerable<TicketMessageServiceModel> GetMessages(int ticketId, int pageIndex, int pageSize, bool includeCreatedBy = false)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketMessageEntityModel>().GetRepository<TicketMessageEntityModel>();

            string includes = "";

            if (includeCreatedBy)
                includes += "CreatedByUser";

            var entities = ticketRepo.Get(x => x.TicketId == ticketId, x => x.OrderBy(y => y.DateCreated), includes)
                                     .Skip(pageIndex * pageSize)
                                     .Take(pageSize)
                                     .ToList();

            var serviceModels = _mapper.Map<List<TicketMessageServiceModel>>(entities);

            return serviceModels;
        }

        public void MarkAsClosed(int ticketId)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>()
                                        .GetRepository<TicketEntityModel>();

            var entity = ticketRepo.GetById(ticketId);

            entity.TicketStatusId = (int)TicketStatusEnum.TicketStatus.Closed;

            ticketRepo.Update(entity);
            _unitOfWork.Save();
        }
    }
}
