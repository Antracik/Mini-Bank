using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Bank.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<AccountRepoModel> _accounts;

        public AccountController(ILogger<AccountController> logger, IRepository<AccountRepoModel> accounts)
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
            return View(_accounts.Get()); 
        }

        public IActionResult DetailsAccount(int id)
        {
            return View(_accounts.Get().FirstOrDefault( ac => ac.Id == id)); 
        }

    }
}