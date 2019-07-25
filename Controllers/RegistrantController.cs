using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class RegistrantController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<WalletRepoModel> _wallets;
        private readonly IRepository<RegistrantRepoModel> _registrant;

        public RegistrantController(ILogger<HomeController> logger, IRepository<WalletRepoModel> wallets, IRepository<RegistrantRepoModel> registrant)
        {
            _logger = logger;
            _wallets = wallets;
            _registrant = registrant;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsRegistrant(int id)
        {
            return View(_registrant.Get().FirstOrDefault(reg => reg.Id == id)); //return View(Generate.GetRegistrants().FirstOrDefault(registrant => registrant.Id == id));
        }

        public IActionResult DisplayRegistrants()
        {
            return View(_registrant.Get()); //return View(Generate.GetRegistrants());
        }

    }
}