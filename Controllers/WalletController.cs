using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly IRepository<WalletRepoModel> _wallets;
        private readonly IRepository<AccountRepoModel> _accounts;

        public WalletController(ILogger<WalletController> logger, IRepository<WalletRepoModel> wallets, IRepository<AccountRepoModel> accounts)
        {
            _logger = logger;
            _wallets = wallets;
            _accounts = accounts;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsWallet(int id)
        {
            return View(_wallets.Get().FirstOrDefault( wal => wal.Id == id));
        }

        public IActionResult DisplayWallets()
        {
            return View(_wallets.Get());
        }
    }
}