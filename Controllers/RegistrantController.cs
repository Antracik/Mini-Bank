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
    public class RegistrantController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegistrantController(ILogger<HomeController> logger, UnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsRegistrant(int id)
        {
            var registrantModel = new RegistrantModel();

            using(_unitOfWork.Add<RegistrantDbRepoModel>().Add<WalletDbRepoModel>())
            {
                var registrantEntity = _unitOfWork.GetRepository<RegistrantDbRepoModel>().Get(reg => reg.Id == id, null, "CountryRelation").FirstOrDefault();

                registrantModel = _mapper.Map<RegistrantModel>(registrantEntity);

                var walletEntities = _unitOfWork.GetRepository<WalletDbRepoModel>().Get(wall => wall.RegistrantId == registrantEntity.Id, null, "Status");

                registrantModel.Wallets = _mapper.Map<List<WalletModel>>(walletEntities);
            }

            return View(registrantModel);
        }

        [HttpGet]
        public IActionResult DisplayRegistrants()
        {
            var registrantModels = new List<RegistrantModel>();
            
            using(_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                var registrantEntities = _unitOfWork.GetRepository<RegistrantDbRepoModel>().Get(null, null, "CountryRelation");

                registrantModels = _mapper.Map<List<RegistrantModel>>(registrantEntities);
            }

            return View(registrantModels);
        }

        [HttpGet("{id}")]
        public IActionResult CreateRegistrantView(int id)
        {
            var registrantModel = new RegistrantModel
            {
                UserId = id
            };

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult CreateRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("CreateRegistrantView", item);
            }

            var registrantEntity = new RegistrantDbRepoModel();

            using (_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                registrantEntity = _mapper.Map<RegistrantDbRepoModel>(item);

                _unitOfWork.GetRepository<RegistrantDbRepoModel>().AddItem(registrantEntity);
                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsRegistrant", new { id = registrantEntity.Id });
        }

        [HttpGet("id")]
        public IActionResult EditRegistrantView(int id)
        {
            var registrantModel = new RegistrantModel();

            using(_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                var registrantEntity = _unitOfWork.GetRepository<RegistrantDbRepoModel>().GetById(id);

                registrantModel = _mapper.Map<RegistrantModel>(registrantEntity);
            }

            return View(registrantModel);
        }

        [HttpPost]
        public IActionResult EditRegistrant(RegistrantModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditRegistrantView", item);
            }

            using(_unitOfWork.Add<RegistrantDbRepoModel>())
            {
                var registrantEntity = _mapper.Map<RegistrantDbRepoModel>(item);

                _unitOfWork.GetRepository<RegistrantDbRepoModel>().Update(registrantEntity);

                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsRegistrant", "Registrant", new { id = item.Id });
        }

        [HttpGet("{id}")]
        public IActionResult DeleteRegistrant(int id)
        {
            int userId;

            using(_unitOfWork.Add<RegistrantDbRepoModel>().Add<WalletDbRepoModel>())
            {
                var registrantRepo = _unitOfWork.GetRepository<RegistrantDbRepoModel>();

                var registrantEntity = registrantRepo.GetById(id);

                if (_unitOfWork.GetRepository<WalletDbRepoModel>()
                    .Get(reg => reg.RegistrantId == registrantEntity.Id)
                    .FirstOrDefault() != null)
                {
                    return View("Error", new ErrorViewModel { RequestId = @"Can't delete registrant info with wallet/s in it" });
                }

                userId = registrantEntity.UserId;

                registrantRepo.Delete(id);

                _unitOfWork.Save();
            }
            
            return RedirectToAction("DetailsUser", "User", new { id = userId });
        }
    }
}