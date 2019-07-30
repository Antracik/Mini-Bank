using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public WalletController(ILogger<WalletController> logger, IRepository<WalletRepoModel> wallets, IRepository<AccountRepoModel> accounts, IMapper mapper)
        {
            _logger = logger;
            _wallets = wallets;
            _accounts = accounts;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsWallet(int id)
        {
            var wallet =_wallets.Get().FirstOrDefault(wal => wal.Id == id);
            var walletAccounts = wallet.GetWalletAccounts(_accounts).ToList();

            WalletModel walletModel = _mapper.Map<WalletModel>(wallet);

            walletModel.Accounts = _mapper.Map<List<AccountModel>>(walletAccounts);

            return View(walletModel);
        }

        public IActionResult DisplayWallets()
        {
            var walletsRepo = _wallets.Get().ToList();

            var walletsModel = _mapper.Map<List<WalletModel>>(walletsRepo);

            return View(walletsModel);
        }

        public IActionResult CreateWalletView(int regId)
        {
            var tempWallet = new WalletModel();

            tempWallet.RegistrantId = regId;

            return View(tempWallet);
        }
       
        [HttpPost]
        public IActionResult CreateWallet(WalletModel item)
        {
            int NewWalletId = _wallets.Get().Max(wID => wID.Id);
            NewWalletId++;
            item.Id = NewWalletId;

            var WalletRepoModel = _mapper.Map<WalletRepoModel>(item);
            WalletRepoModel.IsVerified = false; // making sure that the wallet stays unverified upon creation

            _wallets.AddItem(WalletRepoModel);
            _wallets.SaveChanges();

            return RedirectToAction("DetailsWallet", "Wallet" , new { id = NewWalletId });
        }

        public IActionResult EditWalletView(int id)
        {
            var walletRepo = _wallets.Get().FirstOrDefault(wall => wall.Id == id);

            var walletModel = _mapper.Map<WalletModel>(walletRepo);

            return View(walletModel);
        }

        public IActionResult EditWallet(WalletModel item)
        {
            var walletRepo = _mapper.Map<WalletRepoModel>(item);

            _wallets.Replace(walletRepo);
            _wallets.SaveChanges();

            return RedirectToAction("DetailsWallet", "Wallet", new { id = item.Id });
        }
    }
}