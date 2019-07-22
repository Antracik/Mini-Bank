using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAccounts()
        {
            return View();  //return View(Generate.GetAccounts());
        }

        public IActionResult DetailsAccount(int id)
        {
            return View(); //return View(Generate.GetAccounts().FirstOrDefault(account => account.Id == id));
        }

    }
}