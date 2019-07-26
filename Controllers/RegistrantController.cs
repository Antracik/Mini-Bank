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
            var registrantRepo = _registrant.Get().ToList();
            var registrantModel = _mapper.Map<List<RegistrantModel>>(registrantRepo);

            return View(registrantModel);
        }

    }
}