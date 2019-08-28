using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Extensions;
using Mini_Bank.Models;
using Services.Models;
using Services.Services;
using X.PagedList;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistrantController : Controller
    {

        private readonly IRegistrantService _registrantService;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;

        public RegistrantController(IRegistrantService registrantService, 
                                    INomenclatureService nomenclatureService,
                                    IMapper mapper)
        {
            _mapper = mapper;
            _nomenclatureService = nomenclatureService;
            _registrantService = registrantService;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsRegistrant(int id)
        {
            var registrantServiceModel = _registrantService.GetRegistrantById(id, includeWallets: true);

            var registrantModel = _mapper.Map<RegistrantModel>(registrantServiceModel);

            return View(registrantModel);
        }

        [HttpGet]
        public IActionResult DisplayRegistrants(string sortBy = "", int pageIndex = 1)
        {
            ViewBag.CurrentPage = pageIndex;
            ViewBag.CurrentSort = sortBy;

            ViewBag.IdSort = sortBy.Equals("Id") ? "Id_desc" : "Id";
            ViewBag.FirstNameSort = sortBy.Equals("FirstName") ? "FirstName_desc" : "FirstName";
            ViewBag.LastNameSort = sortBy.Equals("LastName") ? "LastName_desc" : "LastName";
            ViewBag.CountrySort = sortBy.Equals("Country") ? "Country_desc" : "Country";
            ViewBag.AddressSort = sortBy.Equals("Address") ? "Address_desc" : "Address";

            var registrantServiceModel = _registrantService.GetAllRegistrants(sortBy, "");

            var registrantModels = _mapper.Map<List<RegistrantModel>>(registrantServiceModel);

            var pagedModels = registrantModels.ToPagedList(pageIndex, 10);

            return View(pagedModels);
        }

        [HttpGet("{id}")]
        public IActionResult CreateRegistrantView(int id)
        {
            var registrantModel = new RegistrantModel
            {
                UserId = id
            };

            var countriesServiceModel = _nomenclatureService.GetCountries();

            var countriesModel = _mapper.Map<List<CountryModel>>(countriesServiceModel);

            TempData.Put("Countries",countriesModel);

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult CreateRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateRegistrantView", item);
            }

            var registrantServiceModel = _mapper.Map<RegistrantServiceModel>(item);

            int userId = _registrantService.CreateRegistrant(registrantServiceModel); 

            return RedirectToAction("DetailsRegistrant", new { id = userId });
        }

        [HttpGet("id")]
        public IActionResult EditRegistrantView(int id)
        {
            var registrantServiceModel = _registrantService.GetRegistrantById(id);
            var countriesServiceModel = _nomenclatureService.GetCountries();

            var registrantModel = _mapper.Map<RegistrantModel>(registrantServiceModel);
            var countriesModel = _mapper.Map<List<CountryModel>>(countriesServiceModel);

            TempData.Put("Countries", countriesModel);

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult EditRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditRegistrantView", item);
            }

            var registrantModelService = _mapper.Map<RegistrantServiceModel>(item);

            _registrantService.UpdateRegistrant(registrantModelService);

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