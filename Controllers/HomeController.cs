using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Microsoft.Extensions.Logging;
using NLog;

namespace Mini_Bank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index page has a logger now!");
            _logger.LogDebug("I am debug!");
            _logger.LogWarning("I am a warning!");
            _logger.LogTrace("I'm already tracer");
            _logger.LogCritical("I'm probably fatal");
            _logger.LogError("Oooo I am a big scarry error!");
            //List<UserModel> users =  Generate.GenerateUsers();
            //List<RegistrantModel> registrants = Generate.GenerateRegistrants();
            //List<WalletModel> wallets = Generate.GenerateWallets();
            //List<AccountModel> accounts = Generate.GenerateAccounts();

            //_wallets.AddRange(wallets);

            //repo = _wallets.GetCachedRepo();
            
            ////var registrants = new FileRepository<RegistrantModel>().Read();

            ////var registrantWallets = registrants[2].GetRegistrantWallets();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
