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
    public class RegistrantController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<WalletRepoModel> _wallets;
        private readonly IRepository<RegistrantRepoModel> _registrant;
        private readonly IMapper _mapper;

        public RegistrantController(ILogger<HomeController> logger, IRepository<WalletRepoModel> wallets, IRepository<RegistrantRepoModel> registrant, IMapper mapper)
        {
            _logger = logger;
            _wallets = wallets;
            _registrant = registrant;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsRegistrant(int id)
        {
            var registrantRepo = _registrant.Get().FirstOrDefault(reg => reg.Id == id);
            var registrantWallets = registrantRepo.GetRegistrantWallets(_wallets).ToList();

            var registrantModel = _mapper.Map<RegistrantModel>(registrantRepo);

            registrantModel.Wallets = _mapper.Map<List<WalletModel>>(registrantWallets);

            return View(registrantModel);
        }

        public IActionResult DisplayRegistrants()
        {
            var registrantsRepo = _registrant.Get().ToList();
            var registrantsModel = _mapper.Map<List<RegistrantModel>>(registrantsRepo);

            return View(registrantsModel);
        }

        public IActionResult CreateRegistrantView(int id)
        {
            var registrantModel = new RegistrantModel();
            registrantModel.UserId = id;
            
            return View(registrantModel);
        }

        public IActionResult CreateRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateRegistrantView", item);
            }

            int NewRegId = _registrant.Get().Max(rID => rID.Id);
            NewRegId++;
            item.Id = NewRegId;

            var RegistrantRepo = _mapper.Map<RegistrantRepoModel>(item);

            _registrant.AddItem(RegistrantRepo);
            _registrant.SaveChanges();

            return RedirectToAction("DetailsRegistrant", new { id = NewRegId });
        }

        public IActionResult EditRegistrantView(int id)
        {
            var registrantRepo = _registrant.Get().FirstOrDefault(reg => reg.Id == id);

            var registrantModel = _mapper.Map<RegistrantModel>(registrantRepo);

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult EditRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditRegistrantView", item);
            }

            var registrantRepo = _mapper.Map<RegistrantRepoModel>(item);

            _registrant.Replace(registrantRepo);
            _registrant.SaveChanges();

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = item.Id });
        }

        public IActionResult DeleteRegistrant(int id)
        {
            var reginstrantRepo = _registrant.Get().FirstOrDefault(reg => reg.Id == id);

            if (reginstrantRepo.GetRegistrantWallets(_wallets).Count() > 0)
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete registrant info with wallet/s in it" });
            }

            _registrant.Delete(id);
            _registrant.SaveChanges();

            return RedirectToAction("DetailsUser", "User", new { id = reginstrantRepo.UserId });
        }
    }
}