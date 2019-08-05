using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Microsoft.Extensions.Logging;
using NLog;
using Mini_Bank.DbContexts;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using AutoMapper;
using System;
using System.Linq;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, UnitOfWork unitOfWork , IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            //DataSeeder seed = new DataSeeder(_bankContext);
            //seed.SeedDatabase();

            using(_unitOfWork.Add<UserDbRepoModel>().Add<RegistrantDbRepoModel>())
            {
                var testUserRepo = _unitOfWork.GetRepository<UserDbRepoModel>();

                var testUser = testUserRepo.GetById(2);

                testUser.IsAdmin = false;

                testUserRepo.Update(testUser);

                var testRegRepo = _unitOfWork.GetRepository<RegistrantDbRepoModel>();

                var testReg = testRegRepo.GetById(2);

                testReg.FirstName = "Stefan";

                testRegRepo.Update(testReg);

                _unitOfWork.Save();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
