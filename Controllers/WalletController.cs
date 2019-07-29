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
    }
}