﻿using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Services.Models;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class RegistrantController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRegistrantService _registrantService;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;

        public RegistrantController(ILogger<HomeController> logger, 
                                    IRegistrantService registrantService, 
                                    INomenclatureService nomenclatureService,
                                    IMapper mapper)
        {
            _logger = logger;
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
        public IActionResult DisplayRegistrants()
        {
            var registrantServiceModel = _registrantService.GetAllRegistrants();

            var registrantModels = _mapper.Map<List<RegistrantModel>>(registrantServiceModel);

            return View(registrantModels);
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

            ViewBag.Countries = countriesModel;

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

            ViewBag.Countries = countriesModel;

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