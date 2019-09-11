using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Extensions;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Services.Models;
using Services.Services;
using Shared;
using X.PagedList;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class WalletController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRegistrantService _registrantService;
        private readonly IWalletService _walletService;
        private readonly IAccountService _accountService;
        private readonly ICurrencyService _currencyService;
        private readonly IFinancialTransactionService _financialTransactionService;

        public WalletController(IWalletService walletService,
                                IUserService userService,
                                IRegistrantService registrantService,
                                IAccountService accountService,
                                ICurrencyService currencyService,
                                IFinancialTransactionService financialTransactionService,
                                IMapper mapper)
        {
            _registrantService = registrantService;
            _mapper = mapper;
            _userService = userService;
            _currencyService = currencyService;
            _accountService = accountService;
            _financialTransactionService = financialTransactionService;
            _walletService = walletService;
        }

        [HttpGet]
        public IActionResult UserWallets()
        {
            int userId = int.Parse(_userService.GetUserId(User));

            var registrant = _registrantService.GetRegistrantByUserId(userId, includeWallets: true);

            foreach (var wallet in registrant.Wallets)
            {
                wallet.Accounts = _accountService.GetAllAccountsWithWalledId(wallet.Id).ToList();
            }

            var model = new UserWalletsViewModel
            {
                Wallets = _mapper.Map<List<UserWallets>>(registrant.Wallets)
            };

            for (int i = 0; i < registrant.Wallets.Count; i++)
            {
                model.Wallets[i].Verified = registrant.Wallets[i].IsVerified ? "Yes" : "No";
                model.Wallets[i].RowId = "RowGroup" + i;
                model.Wallets[i].Heading = "Heading" + i;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult RequestWallet()
        {
            int userId = int.Parse(_userService.GetUserId(User));

            var registrant = _registrantService.GetRegistrantByUserId(userId, includeWallets: true);

            if (registrant.Wallets.Count >= Constants.maxWalletsPerUser)
            {
                TempData["Message"] = "You are at your max wallet count (" + Constants.maxWalletsPerUser + ")";
                return RedirectToAction("UserWallets");
            }

            var newWallet = new WalletServiceModel
            {
                Number = new Random().Next(100, 999999999),
                RegistrantId = registrant.Id,
                IsVerified = false,
                CreatedById = userId,
                WalletStatusId = (int)StatusEnum.Status.Okay
            };

            _walletService.CreateWallet(newWallet);

            TempData["Message"] = "A new wallet has been requested for creation!";

            return RedirectToAction("UserWallets");
        }

        [HttpGet("{id}")]
        public IActionResult DetailsWallet(int id)
        {
            var walletServiceModel = _walletService.GetWalletById(id, includeAccounts: true);

            var walletModel = _mapper.Map<WalletModel>(walletServiceModel);

            return View(walletModel);
        }

        [HttpGet]
        public IActionResult DisplayWallets(string sortBy = "", int pageIndex = 1)
        {
            ViewBag.CurrentPage = pageIndex;
            ViewBag.CurrentSort = sortBy;

            ViewBag.IdSort = sortBy.Equals("Id") ? "Id_desc" : "Id";
            ViewBag.NumberSort = sortBy.Equals("Number") ? "Number_desc" : "Number";
            ViewBag.WalletStatusSort = sortBy.Equals("WalletStatus") ? "WalletStatus_desc" : "WalletStatus";
            ViewBag.VerifiedSort = sortBy.Equals("Verified") ? "Verified_desc" : "Verified";

            var walletServiceModels = _walletService.GetAllWallets(sortBy, "");

            var walletModels = _mapper.Map<List<WalletModel>>(walletServiceModels);

            var pagedModels = walletModels.ToPagedList(pageIndex, 10);

            return View(pagedModels);
        }

        [HttpPost]
        public IActionResult Transaction(UserWalletsViewModel input )
        {
            var model = TempData.Get<UserWalletsViewModel>("Model");

            if (ModelState.IsValid)
            {
                var sender = _accountService.GetAccountById(input.InputTransaction.FromAccountWithId);

                if(sender == null)
                {
                    model.Message = "Error, account does not exist, please try again!";
                    return View("UserWallets", model);
                }

                // is the senders balance sufficient
                if(sender.Balance <= input.InputTransaction.Amount)
                {
                    model.Message = "Error, insufficient funds in account!";
                    return View("UserWallets", model);
                }

                var recipient = _accountService.GetAccountByIBAN(input.InputTransaction.ToIBAN);//(input.InputTransaction.ToIBAN);

                if(recipient != null)
                {
                    if(sender.Id == recipient.Id)
                    {
                        model.Message = "Error, can't send money to same account!";
                        return View("UserWallets", model);
                    }
                }

                int currentUserId = int.Parse(_userService.GetUserId(User));

                _financialTransactionService.EnactTransaction(sender, input.InputTransaction.Amount, currentUserId, input.InputTransaction.ToIBAN, recipient);

                return RedirectToAction("UserWallets");
            }

            return View("UserWallets", model);
        }

        [HttpGet("{id}")]
        public IActionResult CreateWalletView(int id)
        {
            var tempWallet = new WalletModel
            {
                RegistrantId = id
            };

            return View(tempWallet);
        }

        [HttpPost]
        public IActionResult CreateWallet(WalletModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateWalletView", item);
            }

            int newId;

            var walletServiceModel = _mapper.Map<WalletServiceModel>(item);

            newId = _walletService.CreateWallet(walletServiceModel);

            return RedirectToAction("DetailsWallet", "Wallet", new { id = newId });
        }

        [HttpGet("{id}")]
        public IActionResult EditWalletView(int id)
        {
            var walletServiceModel = _walletService.GetWalletById(id);

            var walletModel = _mapper.Map<WalletModel>(walletServiceModel);

            return View(walletModel);
        }

        [HttpPost]
        public IActionResult EditWallet(WalletModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditWalletView", item);
            }

            var walletServiceModel = _mapper.Map<WalletServiceModel>(item);

            _walletService.UpdateWallet(walletServiceModel);

            return RedirectToAction("DetailsWallet", "Wallet", new { id = item.Id });
        }

        [HttpGet]
        public IActionResult DeleteWallet(int id)
        {
            int regId;

            regId = _walletService.DeleteRegistrant(id);
            if (regId == -1)
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete wallet with accounts" });
            }

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = regId });
        }
    }
}