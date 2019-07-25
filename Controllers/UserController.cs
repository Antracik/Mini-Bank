using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using System.Linq;

namespace Mini_Bank.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<UserRepoModel> _users;
        private readonly IRepository<RegistrantRepoModel> _registrants;

        public UserController(ILogger<AccountController> logger, IRepository<UserRepoModel> users, IRepository<RegistrantRepoModel> registrants)
        {
            _logger = logger;
            _users = users;
            _registrants = registrants; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsUser(int id)
        {
            return View(_users.Get().FirstOrDefault(reg => reg.Id == id));
        }

        public IActionResult DisplayUsers()
        {
            return View(_users.Get());
        }
    }
}