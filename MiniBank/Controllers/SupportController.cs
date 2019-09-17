using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Extensions;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.SharedViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Services.Models;
using Services.Services;
using Shared;

namespace Mini_Bank.Controllers
{
    public class SupportController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;

        public SupportController(IUserService userService, 
                                    ITicketService ticketService, 
                                    IMapper mapper,
                                    INomenclatureService nomenclatureService)
        {
            _userService = userService;
            _ticketService = ticketService;
            _mapper = mapper;
            _nomenclatureService = nomenclatureService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ticketServiceModels = _ticketService.GetAllTickets();

            var ticketTypesServiceModels = _nomenclatureService.GetTicketTypes();

            var model = new TicketViewModel
            {
                UserTickets = _mapper.Map<List<UserTicketViewModel>>(ticketServiceModels),
                TicketTypes = _mapper.Map<List<TicketTypeViewModel>>(ticketTypesServiceModels)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult TicketRequest(TicketViewModel ticket)
        {
            var model = TempData.Get<TicketViewModel>("Model");

            if(ModelState.IsValid)
            {
                var serviceModel = _mapper.Map<TicketServiceModel>(ticket.TicketRequest);

                int userId = int.Parse(_userService.GetUserId(User));

                serviceModel.CreatedById = userId;
                serviceModel.TicketStatusId = (int)TicketStatusEnum.TicketStatus.Open;

                _ticketService.CreateTicket(serviceModel);

                return RedirectToAction("Index");
            }

            model.Message = "Error, please try again";

            return View("Index", model);
        }
    }
}