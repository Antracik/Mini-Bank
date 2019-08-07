using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Services.Models;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class WalletController : Controller
    {
        private readonly ILogger<WalletController> _logger;
        private readonly IMapper _mapper;
        private readonly IWalletService _walletService;
        private readonly INomenclatureService _nomenclatureService;

        public WalletController(ILogger<WalletController> logger, 
                                IWalletService walletService, 
                                INomenclatureService nomenclatureService,
                                IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _nomenclatureService = nomenclatureService;
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsWallet(int id)
        {
            var walletServiceModel = _walletService.GetWalletById(id, includeAccounts: true);

            var walletModel = _mapper.Map<WalletModel>(walletServiceModel);

            return View(walletModel);
        }

        [HttpGet]
        public IActionResult DisplayWallets()
        {
            var walletServiceModels = _walletService.GetAllWallets();

            var walletModels = _mapper.Map<List<WalletModel>>(walletServiceModels);

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

            var walletServiceModel = _mapper.Map<WalletServiceModel>(item);

            newId = _walletService.CreateWallet(walletServiceModel);

            return RedirectToAction("DetailsWallet", "Wallet" , new { id = newId });
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
            if(!ModelState.IsValid)
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
            if(regId == -1)
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete wallet with accounts" });
            }

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = regId });
        }
    }
}