using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WalletController(ILogger<WalletController> logger, UnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsWallet(int id)
        {
            var walletModel = new WalletModel();

            using(_unitOfWork.Add<WalletDbRepoModel>().Add<AccountDbRepoModel>())
            {
                var walletEntity = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(wall => wall.Id == id, null, "Status").FirstOrDefault();
                var walletAccounts = _unitOfWork.GetRepository<AccountDbRepoModel>().Get(wall => wall.WalletId == walletEntity.Id, null, "Status,CurrencyRelation");

                walletModel = _mapper.Map<WalletModel>(walletEntity);
                walletModel.Accounts = _mapper.Map<List<AccountModel>>(walletAccounts);
            }
            
            return View(walletModel);
        }

        [HttpGet]
        public IActionResult DisplayWallets()
        {
            var walletModels = new List<WalletModel>();

            using(_unitOfWork.Add<WalletDbRepoModel>())
            {
                var walletEntities = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(null, null, "Status");

                walletModels = _mapper.Map<List<WalletModel>>(walletEntities);
            }

            return View(walletModels);
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
            if(!ModelState.IsValid)
            {
                return View("CreateWalletView", item);
            }

            int newId;

            using(_unitOfWork.Add<WalletDbRepoModel>())
            {
                var walletEntity = _mapper.Map<WalletDbRepoModel>(item);

                walletEntity.RegistrantId = item.RegistrantId;

                _unitOfWork.GetRepository<WalletDbRepoModel>().AddItem(walletEntity);
                _unitOfWork.Save();

                newId = walletEntity.Id;
            }


            return RedirectToAction("DetailsWallet", "Wallet" , new { id = newId });
        }

        [HttpGet("{id}")]
        public IActionResult EditWalletView(int id)
        {
            var walletModel = new WalletModel();

            using(_unitOfWork.Add<WalletDbRepoModel>())
            {
                var walletEntity = _unitOfWork.GetRepository<WalletDbRepoModel>().GetById(id);

                walletModel = _mapper.Map<WalletModel>(walletEntity);
            }

            return View(walletModel);
        }

        [HttpPost]
        public IActionResult EditWallet(WalletModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditWalletView", item);
            }

            using(_unitOfWork.Add<WalletDbRepoModel>())
            {
                var walletEntity = _mapper.Map<WalletDbRepoModel>(item);

                _unitOfWork.GetRepository<WalletDbRepoModel>().Update(walletEntity);
                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsWallet", "Wallet", new { id = item.Id });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteWallet(int id)
        {
            int regId;

            using(_unitOfWork.Add<WalletDbRepoModel>().Add<AccountDbRepoModel>())
            {
                var wallRepo = _unitOfWork.GetRepository<WalletDbRepoModel>();
                var walletEntity = wallRepo.GetById(id);

                if(_unitOfWork.GetRepository<AccountDbRepoModel>()
                    .Get(acc => acc.WalletId == walletEntity.Id)
                    .FirstOrDefault() != null)
                {
                    return View("Error", new ErrorViewModel { RequestId = @"Can't delete wallet with accounts" });
                }

                regId = walletEntity.RegistrantId;

                wallRepo.Delete(id);
                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = regId });
        }
    }
}