using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View(Generate.GetWallets().FirstOrDefault(wallet => wallet.Id == id));
        }

        public IActionResult DisplayWallets()
        {
            return View(Generate.GetWallets());
        }
    }
}