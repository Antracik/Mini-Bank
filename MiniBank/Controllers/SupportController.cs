using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Extensions;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.SharedViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Newtonsoft.Json;
using Services.Models;
using Services.Services;
using Shared;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
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
        public IActionResult Chat()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            int userId = int.Parse(_userService.GetUserId(User));

            var ticketServiceModels = _ticketService.GetAllTicketsForUser(userId);
            var ticketTypesServiceModels = _nomenclatureService.GetTicketTypes();

            var model = new TicketViewModel
            {
                UserTickets = _mapper.Map<List<UserTicketViewModel>>(ticketServiceModels),
                TicketTypes = _mapper.Map<List<TicketTypeViewModel>>(ticketTypesServiceModels)
            };

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminTickets()
        {
            var ticketServiceModels = _ticketService.GetAllTickets();

            var ticketTypesServiceModels = new List<TicketTypeServiceModel>
                                            {
                                                new TicketTypeServiceModel { Id = 0, Name ="All" }
                                            };

            ticketTypesServiceModels.AddRange(_nomenclatureService.GetTicketTypes());

            var model = new TicketViewModel
            {
                UserTickets = _mapper.Map<List<UserTicketViewModel>>(ticketServiceModels),
                TicketTypes = _mapper.Map<List<TicketTypeViewModel>>(ticketTypesServiceModels)
            };

            return View("Tickets", model);
        }

        [HttpPost]
        public IActionResult TicketRequest(TicketViewModel ticket)
        {
            var model = TempData.Get<TicketViewModel>("Model");

            if (ModelState.IsValid)
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

        [HttpGet("{id}")]
        public IActionResult GetTicketDetails(int id)
        {
            int userId = int.Parse(_userService.GetUserId(User));

            var entity = _ticketService.GetTicket(userId, id);

            if (entity == null)
                return NotFound();

            var serviceModel = _mapper.Map<TicketDetailsViewModel>(entity);

            return new JsonResult(serviceModel);
        }

        [HttpGet("{pageIndex}/{ticketId}")]
        public IActionResult GetMessages(int pageIndex, int ticketId)
        {
            var messagesServiceModel = _ticketService.GetMessages(ticketId, pageIndex, 10, true);

            if (messagesServiceModel.Any())
            {
                var test = new List<object>();

                foreach (var model in messagesServiceModel)
                {
                    test.Add(new {
                        message = model.Message,
                        date = model.DateCreated.ToString("MM/dd/yyyy HH:mm:ss"),
                        userName = model.CreatedByUser.Email
                    });

                }

                return new JsonResult(test, new JsonSerializerSettings
                {
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                });
            }

            return NotFound();
        }

        [HttpPost("{ticketId}/{message}")]
        public IActionResult SendMessage(int ticketId, string message)
        {
            if (message.Length > 1000)
            {
                return new JsonResult(new { Status = "error", Reason = "Message cannot be over 1000 characters" });
            }

            int userId = int.Parse(_userService.GetUserId(User));
            var ticket = _ticketService.GetTicketById(ticketId, true);
            bool isAdmin = _userService.IsUserSignedInAsAdmin(User);

            if (ticket != null)
            {
                if ((isAdmin || ticket.CreatedById.Value == userId) && ticket.TicketStatusId == (int)TicketStatusEnum.TicketStatus.Open)
                {
                    var messageServiceModel = new TicketMessageServiceModel
                    {
                        Message = message,
                        TicketId = ticket.Id,
                        CreatedById = userId,
                        DateCreated = DateTime.Now
                    };

                    _ticketService.CreateMessage(messageServiceModel);

                    return new JsonResult(
                        new
                        {
                            Status = "success",
                            Message = message,
                            Date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"),
                            UserName = ticket.CreatedByUser.Email
                        });
                }
            }

            return new JsonResult(new { Status = "error", Reason = "An error occured, please try again later" });
        }

        [HttpPost("{ticketId}")]
        public IActionResult CloseTicket(int ticketId)
        {
            int userId = int.Parse(_userService.GetUserId(User));

            var ticket = _ticketService.GetTicketById(ticketId, true);

            if (ticket != null)
            {
                if (ticket.TicketStatusId == (int)TicketStatusEnum.TicketStatus.Closed)
                {
                    return new JsonResult(new { Status = "error", Reason = "Ticket is already closed" });
                }

                if (_userService.IsUserSignedInAsAdmin(User) || ticket.CreatedById.Value == userId)
                {
                    _ticketService.MarkAsClosed(ticketId);

                    return new JsonResult(new { Status = "success" });
                }
            }

            return new JsonResult(new { Status = "success", Reason = "An error occured, please try again later" });
        }
    }
}