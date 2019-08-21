using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Extensions;
using Mini_Bank.Models;
using Services.Models;
using System.Collections.Generic;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly INomenclatureService _nomenclatureService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService,
                                INomenclatureService nomenclatureService,
                                IMapper mapper)
        {
            _mapper = mapper;
            _nomenclatureService = nomenclatureService;
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult DisplayAccounts()
        {
            var accountServiceModel = _accountService.GetAllAccounts();

            var accountModels = _mapper.Map<List<AccountModel>>(accountServiceModel);

           return View(accountModels);
        }

        [HttpGet("{id}")]
        public IActionResult DetailsAccount(int id)
        {
            var accountServiceModel = _accountService.GetAccountById(id);

            var accountModel = _mapper.Map<AccountModel>(accountServiceModel);

            return View(accountModel); 
        }

        [HttpGet("walletId")]
        public IActionResult CreateAccountView(int walletId)
        {
            var tempAccount = new AccountModel
            {
                WalletId = walletId
            };

            var currenciesServiceModel = _nomenclatureService.GetCurrencies();

            var currenciesModel = _mapper.Map<List<CurrencyModel>>(currenciesServiceModel);

            TempData.Put("Currencies", currenciesModel);

            return View(tempAccount);
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateAccountView", item);
            }

            var accountServiceModel = _mapper.Map<AccountServiceModel>(item);

            int newId = _accountService.CreateAccount(accountServiceModel);
           
            return RedirectToAction("DetailsAccount", "Account", new { id = newId });
        }

        [HttpGet("{id}")]
        public IActionResult EditAccountView(int id)
        {
            var accountServiceModel = _accountService.GetAccountById(id);

            var accountModel = _mapper.Map<AccountModel>(accountServiceModel);

            return View(accountModel);
        }

        [HttpPost]
        public IActionResult EditAccount(AccountModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditAccountView", item);
            }

            var accountServiceModel = _mapper.Map<AccountServiceModel>(item);

            _accountService.UpdateAccount(accountServiceModel);

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