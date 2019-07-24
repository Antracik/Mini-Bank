using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Mini_Bank.Models.Repository;

namespace Mini_Bank.Controllers
{
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly IRepository<WalletModel> _wallets;

        public WalletController(ILogger<WalletController> logger, IRepository<WalletModel> wallets)
        {
            _logger = logger;
            _wallets = wallets;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsWallet(int id)
        {
            return View(); //return View(Generate.GetWallets().FirstOrDefault(wallet => wallet.Id == id));
        }

        public IActionResult DisplayWallets()
        {
            return View(); //return View(Generate.GetWallets());
        }
    }
}