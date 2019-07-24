using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Mini_Bank.Models.Repository;

namespace Mini_Bank.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<AccountModel> _accounts;

        public UserController(ILogger<AccountController> logger, IRepository<AccountModel> accounts)
        {
            _logger = logger;
            _accounts = accounts;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsUser(int id)
        {
            return View(); //return View(Generate.GetUsers().FirstOrDefault(user => user.Id == id));
        }

        public IActionResult DisplayUsers()
        {
            return View(); //return View(Generate.GetUsers());
        }
    }
}