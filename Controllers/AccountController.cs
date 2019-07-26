using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Bank.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<AccountRepoModel> _accounts;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IRepository<AccountRepoModel> accounts, IMapper mapper)
        {
            _logger = logger;
            _accounts = accounts;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAccounts()
        {
            var accounts = _accounts.Get();

            var res = _mapper.Map<List<AccountModel>>(accounts);

            return View(res); 
        }

        public IActionResult DetailsAccount(int id)
        {
            AccountRepoModel accRepo = _accounts.Get().FirstOrDefault(ac => ac.Id == id);

            var res = _mapper.Map<AccountModel>(accRepo);

            return View(res); 
        }

    }
}