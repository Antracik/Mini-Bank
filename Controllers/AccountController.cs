using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Mini_Bank.Models.Repository;

namespace Mini_Bank.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<AccountModel> _accounts;

        public AccountController(ILogger<AccountController> logger, IRepository<AccountModel> accounts)
        {
            _logger = logger;
            _accounts = accounts;
        }

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