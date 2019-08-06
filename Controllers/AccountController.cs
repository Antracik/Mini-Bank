using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _accountService = accountService;
        }

        
        [HttpGet]
        public IActionResult DisplayAccounts()
        {
            var accountEntities = _accountService.GetAllAccounts();

            var accountModels = _mapper.Map<List<AccountModel>>(accountEntities);

           return View(accountModels);
        }

        [HttpGet("{id}")]
        public IActionResult DetailsAccount(int id)
        {
            var accountEntity = _accountService.GetAccountById(id);

            var accountModel = _mapper.Map<AccountModel>(accountEntity);

            return View(accountModel); 
        }

        [HttpGet("walletId")]
        public IActionResult CreateAccountView(int walletId)
        {
            var tempAccount = new AccountModel
            {
                WalletId = walletId
            };

            return View(tempAccount);
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateAccountView", item);
            }

            int newId = _accountService.CreateAccount(item);
           
            return RedirectToAction("DetailsAccount", "Account", new { id = newId });
        }

        [HttpGet("{id}")]
        public IActionResult EditAccountView(int id)
        {
            var accountEntity = _accountService.GetAccountById(id);

            var accountModel = _mapper.Map<AccountModel>(accountEntity);

            return View(accountModel);
        }

        [HttpPost]
        public IActionResult EditAccount(AccountModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditAccountView", item);
            }

            _accountService.UpdateAccount(item);

            return RedirectToAction("DetailsAccount", "Account", new { id = item.Id });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            int wallId;

            wallId = _accountService.DeleteAccount(id);

            return RedirectToAction("DetailsWallet", "Wallet", new { id = wallId });
        }
    }
}