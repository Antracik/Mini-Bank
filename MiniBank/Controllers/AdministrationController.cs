using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Extensions;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Mini_Bank.Models.ViewModels.SharedViewModels;
using Mini_Bank.Models.ViewModels.UtilityModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Services.Models;
using Services.Services;
using Shared;
using X.PagedList;

namespace Mini_Bank.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class AdministrationController : Controller
    {

        private readonly IAdministrationService _administraionService;
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;
        private readonly IAccountService _accountService;
        private readonly IFinancialTransactionService _financialTransactionService;

        public AdministrationController(IAdministrationService administraionService,
                                        IMapper mapper,
                                        IUserService userService,
                                        IAccountService accountService,
                                        IWalletService walletService,
                                        IFinancialTransactionService financialTransactionService,
                                        INomenclatureService nomenclatureService)
        {
            _administraionService = administraionService;
            _mapper = mapper;
            _accountService = accountService;
            _userService = userService;
            _financialTransactionService = financialTransactionService;
            _walletService = walletService;
            _nomenclatureService = nomenclatureService;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transaction(AccountDetailsViewModel input)
        {
            var model = TempData.Get<AccountDetailsViewModel>("Model");

            if (ModelState.IsValid)
            {
                var sender = _accountService.GetAccountById(input.InputTransaction.FromAccountWithId);

                if (sender == null)
                {
                    model.Message = "Error, account does not exist, please try again!";
                    return View("../Account/DetailsAccount", model);
                }

                // is the senders balance sufficient
                if (sender.Balance <= input.InputTransaction.Amount)
                {
                    model.Message = "Error, insufficient funds in user account!";
                    return View("../Account/DetailsAccount", model);
                }

                var recipient = _accountService.GetAccountByIBAN(input.InputTransaction.ToIBAN);

                if (recipient != null)
                {
                    if (sender.Id == recipient.Id)
                    {
                        model.Message = "Error, can't send money to same user account!";
                        return View("../Account/DetailsAccount", model);
                    }
                }

                int currentUserId = int.Parse(_userService.GetUserId(User));

                int transactionId = _financialTransactionService.EnactTransaction(sender, input.InputTransaction.Amount, currentUserId, input.InputTransaction.ToIBAN, recipient);
                
                if(transactionId == int.MinValue)
                {
                    model.Message = "There was an error while enacting the transaction, please try again later.";
                    return View("../Account/DetailsAccount", model);
                }

                return RedirectToAction("DetailsAccount", "Account", new { model.Id });
            }

            return View("../Account/DetailsAccount", model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                RoleModel roleModel = new RoleModel
                {
                    Name = roleViewModel.Name
                };

                IdentityResult result = await _administraionService.CreateRoleAsync(roleModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(roleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListRoles()
        {
            var roles = _administraionService.GetRoles();

            var rolesViewModels = _mapper.Map<List<RoleViewModel>>(roles);

            foreach (var role in rolesViewModels)
            {
                var res = await _administraionService.GetUsersInRoleAsync(role.Name);
                role.TotalUsers = res.Count;
            }

            return View(rolesViewModels);
        }

        [HttpGet]
        public IActionResult WalletVerificationList()
        {
            var wallets = _walletService.GetAllWallets(x => x.IsVerified == false, x => x.OrderBy(y => y.RegistrantId));

            var model = _mapper.Map<List<WalletVerificationListViewModel>>(wallets);

            return View(model);
        }

        [HttpGet]
        public IActionResult VerifyWallet(int walletNumber)
        {
            var wallet = _walletService.GetWalletByWalletNumber(walletNumber, includeAccounts: true);

            var model = _mapper.Map<VerifyWalletViewModel>(wallet);

            model.CurrencyList = _mapper.Map<List<CurrencyModel>>(_nomenclatureService.GetCurrencies());

            return View(model);
        }

        [HttpPost]
        public IActionResult VerifyWallet(AccountInputModel account, int walletNumber, bool verify = false)
        {
            var wallet = _walletService.GetWalletByWalletNumber(walletNumber, true);

            if (wallet == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = "Error, wallet does not exist" });
            }

            // Modal for verification
            if (verify)
            {
                wallet.IsVerified = true;
                _walletService.UpdateWallet(wallet);

                return RedirectToAction("WalletVerificationList");
            }

            // Modal for adding accounts to the wallet before it is verified
            if (!ModelState.IsValid)
            {
                var model = _mapper.Map<VerifyWalletViewModel>(wallet);

                model.CurrencyList = _mapper.Map<List<CurrencyModel>>(_nomenclatureService.GetCurrencies());

                return View(model);
            }

            var acc = _mapper.Map<AccountServiceModel>(account);

            acc.WalletId = wallet.Id;
            acc.AccountStatusId = (int)StatusEnum.Status.Okay;
            acc.CreatedById = int.Parse(_userService.GetUserId(User));

            _accountService.CreateAccount(acc);

            return RedirectToAction("VerifyWallet", new { walletNumber });
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            RoleModel role = await _administraionService.FindRoleByIdAsync(Id);

            if (role == null)
            {
                return RedirectToAction("Error", new ErrorViewModel { RequestId = $@"Role with Id: {Id} not found" });
            }

            var editRole = _mapper.Map<EditRoleViewModel>(role);

            foreach (var user in _administraionService.GetUsers())
            {
                if (await _administraionService.IsUserInRoleAsync(user, role.Name))
                {
                    editRole.Users.Add(user.Email);
                }
            }

            return View(editRole);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            int tempId = (int)TempData["id"];

            RoleModel role = await _administraionService.FindRoleByIdAsync(tempId.ToString());

            if (role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $@"Role with Id: {tempId} not found" });
            }
            else
            {
                role.Name = model.Name;

                var result = await _administraionService.UpdateRoleAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                //Something went wrong, put Id back in TempData
                TempData["id"] = tempId;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _administraionService.FindRoleByIdAsync(roleId);

            if (role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $"No role with Id: {roleId} found" });
            }

            var models = new List<UserRoleViewModel>();

            foreach (var user in _administraionService.GetUsers())
            {
                var userRole = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.Email
                };

                if (await _administraionService.IsUserInRoleAsync(user, role.Name))
                {
                    userRole.IsSelected = true;
                }
                else
                {
                    userRole.IsSelected = false;
                }

                models.Add(userRole);
            }

            TempData["roleId"] = roleId;

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> models)
        {
            string roleId = TempData["roleId"].ToString();

            var role = await _administraionService.FindRoleByIdAsync(roleId);

            if (role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $"No role with Id: {roleId} found" });
            }

            for (int i = 0; i < models.Count; i++)
            {
                var user = await _administraionService.FindUserByIdAsync(models[i].UserId.ToString());

                IdentityResult result;

                if (models[i].IsSelected && !(await _administraionService.IsUserInRoleAsync(user, role.Name)))
                {
                    result = await _administraionService.AddUserToRoleAsync(user, role.Name);
                }
                else if (!models[i].IsSelected && await _administraionService.IsUserInRoleAsync(user, role.Name))
                {
                    result = await _administraionService.RemoveUserFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (models.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", "Administration", new { Id = roleId });
                    }
                }
            }

            //If empty go back to edit role
            return RedirectToAction("EditRole", "Administration", new { Id = roleId });
        }

        [HttpGet]
        public IActionResult AllWalletsWithSums(AllWalletsWithSumsViewModel model, string prevFilters, string sortBy = "", int pageIndex = 1)
        {
            var countries = _mapper.Map<List<CountryModel>>(_nomenclatureService.GetCountries()).OrderBy(x => x.Name).ToList();

            pageIndex = pageIndex > 0 ? pageIndex : 1;

            model.Countries = countries;
            model.CurrentPage = pageIndex;
            model.CurrentSort = sortBy;

            if (prevFilters != null)
            {
                model.Filters = JsonConvert.DeserializeObject<AllWalletsWithSumsFilters>(prevFilters);
            }

            model.IdSort = sortBy.Equals("Id") ? "Id_desc" : "Id";
            model.ClientNameSort = sortBy.Equals("ClientName") ? "ClientName_desc" : "ClientName";
            model.ClientCountrySort = sortBy.Equals("ClientCountry") ? "ClientCountry_desc" : "ClientCountry";
            model.BalanceSort = sortBy.Equals("Balance") ? "Balance_desc" : "Balance";
            model.CurrencySort = sortBy.Equals("Currency") ? "Currency_desc" : "Currency";

            var filterServiceModel = _mapper.Map<AllWalletsWithSumsFiltersServiceModel>(model.Filters);

            var test = _administraionService.GetAllWalletsWithSums(sortBy, filterServiceModel);

            model.Data = test.ToPagedList(pageIndex, 10);

            return View(model);
        }

    }
}