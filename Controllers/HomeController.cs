using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Generate.GenAll();
            List<UserModel> users =  Generate.GenerateUsers();
            List<RegistrantModel> registrants = Generate.GenerateRegistrants();
            List<WalletModel> wallets = Generate.GenerateWallets();
            List<AccountModel> accounts = Generate.GenerateAccounts();

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
