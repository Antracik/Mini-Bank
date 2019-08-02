using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Microsoft.Extensions.Logging;
using NLog;
using Mini_Bank.DbContexts;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDbRepository<UserDbRepoModel> _userRepo;
        private readonly BankContext _bankContext;

        public HomeController(ILogger<HomeController> logger, BankContext context, IDbRepository<UserDbRepoModel> userRepo)
        {
            _logger = logger;
            _bankContext = context;
            _userRepo = userRepo;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            //DataSeeder seed = new DataSeeder(_bankContext);
            //seed.SeedDatabase();
            var user = _userRepo.GetById(2);

            user.IsAdmin = false;

            _userRepo.Update(user);
            _userRepo.SaveChanges();

            var users = _userRepo.GetAll();

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
