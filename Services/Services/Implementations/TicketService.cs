﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;

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

        public IEnumerable<TicketServiceModel> GetAllTickets()
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>().GetRepository<TicketEntityModel>();

            var entities = ticketRepo.Get(includeProperties: "TicketStatus,TicketType");

            var serviceModels = _mapper.Map<List<TicketServiceModel>>(entities);

            return serviceModels;
        }

        public TicketServiceModel GetTicketById(int id)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>().GetRepository<TicketEntityModel>();

            var entity = ticketRepo.Get(x => x.Id == id, includeProperties: "TicketStatus,TicketType");

            var serviceModel = _mapper.Map<TicketServiceModel>(entity);

            return serviceModel;
        }

        public TicketServiceModel GetTicket(int userId, int ticketId)
        {
            var ticketRepo = _unitOfWork.AddRepository<TicketEntityModel>().GetRepository<TicketEntityModel>();

            var entity = ticketRepo.Get(x => x.Id == ticketId && x.CreatedById == userId, includeProperties: "TicketStatus,TicketType").FirstOrDefault();

            var serviceModel = _mapper.Map<TicketServiceModel>(entity);

            return serviceModel;
        }
    }
}