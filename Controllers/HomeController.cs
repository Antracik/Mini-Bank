using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DisplayUsers()
        {
            return View(Generate.GetUsers());
        }

        public IActionResult DisplayRegistrants()
        {
            return View(Generate.GetRegistrants());
        }

        public IActionResult DisplayWallets()
        {
            return View(Generate.GetWallets());
        }

        public IActionResult DisplayAccounts()
        {
            return View(Generate.GetAccounts());
        }

        public IActionResult DetailsUser(int id)
        {
            return View(Generate.GetUsers().FirstOrDefault(user => user.Id == id));
        }

        public IActionResult DetailsRegistrant(int id)
        {
            return View(Generate.GetRegistrants().FirstOrDefault( registrant => registrant.Id == id));
        }

        public IActionResult DetailsWallet(int id)
        {
            return View(Generate.GetWallets().FirstOrDefault( wallet => wallet.Id == id));
        }

        public IActionResult DetailsAccount(int id)
        {
            return View(Generate.GetAccounts().FirstOrDefault(account => account.Id == id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
