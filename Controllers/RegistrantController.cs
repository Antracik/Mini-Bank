using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Services;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistrantController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRegistrantService _registrantService;
        private readonly IMapper _mapper;

        public RegistrantController(ILogger<HomeController> logger, IRegistrantService registrantService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _registrantService = registrantService;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsRegistrant(int id)
        {

            var registrantEntity = _registrantService.GetRegistrantById(id, includeWallets: true);

            var registrantModel = _mapper.Map<RegistrantModel>(registrantEntity);

            return View(registrantModel);
        }

        [HttpGet]
        public IActionResult DisplayRegistrants()
        {

            var registrantEntities = _registrantService.GetAllRegistrants();

            var registrantModels = _mapper.Map<List<RegistrantModel>>(registrantEntities);

            return View(registrantModels);
        }

        [HttpGet("{id}")]
        public IActionResult CreateRegistrantView(int id)
        {
            var registrantModel = new RegistrantModel
            {
                UserId = id
            };

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult CreateRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateRegistrantView", item);
            }

            int userId = _registrantService.CreateRegistrant(item); 

            return RedirectToAction("DetailsRegistrant", new { id = userId });
        }

        [HttpGet("id")]
        public IActionResult EditRegistrantView(int id)
        {

            var registrantEntity = _registrantService.GetRegistrantById(id);

            var registrantModel = _mapper.Map<RegistrantModel>(registrantEntity);

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult EditRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditRegistrantView", item);
            }

            _registrantService.UpdateRegistrant(item);

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = item.Id });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteRegistrant(int id)
        {
            int userId;

            userId = _registrantService.DeleteRegistrant(id);

            if(userId == -1)
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete registrant info with wallet/s in it" });
            }
            
            return RedirectToAction("DetailsUser", "User", new { id = userId });
        }
    }
}