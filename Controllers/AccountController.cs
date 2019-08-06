using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
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
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, UnitOfWork unitOfWork , IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult DisplayAccounts()
        {
            var accountModels = new List<AccountModel>();

            using(_unitOfWork.Add<AccountDbRepoModel>())
            {
                var accountEntities = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(null, null, "Status,CurrencyRelation");

                accountModels = _mapper.Map<List<AccountModel>>(accountEntities);
            }

           return View(accountModels);
        }

        [HttpGet("{id}")]
        public IActionResult DetailsAccount(int id)
        {
            var accountModel = new AccountModel();

            using(_unitOfWork.Add<AccountDbRepoModel>())
            {
                var accountEntity = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(acc => acc.Id == id, null, "Status,CurrencyRelation").FirstOrDefault();

                accountModel = _mapper.Map<AccountModel>(accountEntity);
            }

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

            var accountEntity = new AccountDbRepoModel();

            using(_unitOfWork.Add<AccountDbRepoModel>())
            {
                accountEntity = _mapper.Map<AccountDbRepoModel>(item);

                _unitOfWork.GetRepository<AccountDbRepoModel>().AddItem(accountEntity);
                _unitOfWork.Save();
            }
           
            return RedirectToAction("DetailsAccount", "Account", new { id = accountEntity.Id });
        }

        [HttpGet("{id}")]
        public IActionResult EditAccountView(int id)
        {
            var accountModel = new AccountModel();

            using(_unitOfWork.Add<AccountDbRepoModel>())
            {
                var accountEntity = _unitOfWork.GetRepository<AccountDbRepoModel>().GetById(id);

                accountModel = _mapper.Map<AccountModel>(accountEntity);
            }

            return View(accountModel);
        }

        [HttpPost]
        public IActionResult EditAccount(AccountModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("EditAccountView", item);
            }

            using(_unitOfWork.Add<AccountDbRepoModel>())
            {
                 var accountEntity = _mapper.Map<AccountDbRepoModel>(item);

                _unitOfWork.GetRepository<AccountDbRepoModel>().Update(accountEntity);
                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsAccount", "Account", new { id = item.Id });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            int wallId;

            using(_unitOfWork.Add<AccountDbRepoModel>())
            {
                var accountRepo = _unitOfWork.GetRepository<AccountDbRepoModel>();

                wallId = accountRepo.Get(acc => acc.Id == id).FirstOrDefault().WalletId;

                accountRepo.Delete(id);

                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsWallet", "Wallet", new { id = wallId });
        }
    }
}