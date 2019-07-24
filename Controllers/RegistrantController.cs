using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Mini_Bank.Models.Repository;

namespace Mini_Bank.Controllers
{
    public class RegistrantController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<WalletModel> _wallets;

        public RegistrantController(ILogger<HomeController> logger, IRepository<WalletModel> wallets)
        {
            _logger = logger;
            _wallets = wallets;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsRegistrant(int id)
        {
            return View(); //return View(Generate.GetRegistrants().FirstOrDefault(registrant => registrant.Id == id));
        }

        public IActionResult DisplayRegistrants()
        {
            return View(); //return View(Generate.GetRegistrants());
        }

    }
}