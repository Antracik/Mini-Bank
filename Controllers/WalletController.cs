using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class WalletController : Controller
    {
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