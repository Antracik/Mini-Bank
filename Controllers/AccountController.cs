using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<AccountRepoModel> _accounts;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IRepository<AccountRepoModel> accounts, IMapper mapper)
        {
            _logger = logger;
            _accounts = accounts;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult DisplayAccounts()
        {
           _logger.LogInformation("Entering display accounts and starting file read");

           var accountsRepo = _accounts.Get();

           _logger.LogInformation($"Read : {accountsRepo.ToList().Count} accounts");
           var accountsModel = _mapper.Map<List<AccountModel>>(accountsRepo);

           return View(accountsModel);
        }

        [HttpGet("{id}")]
        public IActionResult DetailsAccount(int id)
        {
            var accountRepo = _accounts.Get().FirstOrDefault(ac => ac.Id == id);

            var accountModel = _mapper.Map<AccountModel>(accountRepo);

            return View(accountModel); 
        }

        [HttpGet("walletId")]
        public IActionResult CreateAccountView(int walletId)
        {
            var tempAccount = new AccountModel();
            tempAccount.WalletId = walletId;

            return View(tempAccount);
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateAccountView", item);
            }

            int NewAccountId = _accounts.Get().Max(aID => aID.Id);
            NewAccountId++;
            item.Id = NewAccountId;

            var AccountRepoModel = _mapper.Map<AccountRepoModel>(item);

            _accounts.AddItem(AccountRepoModel);
            _accounts.SaveChanges();

            return RedirectToAction("DetailsAccount", "Account", new { id = NewAccountId });
        }

        [HttpGet("{id}")]
        public IActionResult EditAccountView(int id)
        {
            var accountRepo = _accounts.Get().FirstOrDefault(acc => acc.Id == id);

            var accountModel = _mapper.Map<AccountModel>(accountRepo);

            return View(accountModel);
        }

        [HttpPut]
        public IActionResult EditAccount(AccountModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditAccountView", item);
            }

            var accountRepo = _mapper.Map<AccountRepoModel>(item);

            _accounts.Replace(accountRepo);
            _accounts.SaveChanges();

            return RedirectToAction("DetailsAccount", "Account", new { id = item.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            int walletId = _accounts.Get().FirstOrDefault(acc => acc.Id == id).WalletId;

            _accounts.Delete(id);
            _accounts.SaveChanges();

            return RedirectToAction("DetailsWallet", "Wallet", new { id = walletId });
        }
    }
}