using System.Collections.Generic;
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
            var regs = _registrant.Get().FirstOrDefault(reg => reg.Id == id);
            var wal = regs.GetRegistrantWallets(_wallets).ToList();

            var registrant = new RegistrantModel();
            registrant.Wallets = new List<WalletModel>();

            registrant.Id = regs.Id;
            registrant.Name = regs.Name;
            registrant.Country = regs.Country;
            registrant.Address = regs.Address;

            for (int i = 0; i < wal.Count; i++)
            {
                registrant.Wallets.Add(new WalletModel(wal[i].Id, wal[i].Number, wal[i].WalletStatus, null));
            }

            return View(registrant);
        }

        public IActionResult DisplayRegistrants()
        {
            return View(_registrant.Get());
        }

    }
}