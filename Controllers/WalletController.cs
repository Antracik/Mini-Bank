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
using Mini_Bank.Services;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWalletService _walletService;

        public WalletController(ILogger<WalletController> logger, IWalletService walletService ,UnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _walletService = walletService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsWallet(int id)
        {
            var walletEntity = _walletService.GetWalletById(id, includeAccounts: true);

            var walletModel = _mapper.Map<WalletModel>(walletEntity);

            return View(walletModel);
        }

        [HttpGet]
        public IActionResult DisplayWallets()
        {
            var waletEntities = _walletService.GetAllWallets();

            var walletModels = _mapper.Map<List<WalletModel>>(waletEntities);

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

            newId = _walletService.CreateWallet(item);

            return RedirectToAction("DetailsWallet", "Wallet" , new { id = newId });
        }

        [HttpGet("{id}")]
        public IActionResult EditWalletView(int id)
        {
            var walletEntity = _walletService.GetWalletById(id);

            var walletModel = _mapper.Map<WalletModel>(walletEntity);

            return View(walletModel);
        }

        [HttpPost]
        public IActionResult EditWallet(WalletModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditWalletView", item);
            }

            _walletService.UpdateWallet(item);

            return RedirectToAction("DetailsWallet", "Wallet", new { id = item.Id });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteWallet(int id)
        {
            int regId;

            regId = _walletService.DeleteRegistrant(id);
            if(regId == -1)
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete wallet with accounts" });
            }

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = regId });
        }
    }
}