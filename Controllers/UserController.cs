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
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<UserRepoModel> _users;
        private readonly IRepository<RegistrantRepoModel> _registrants;
        private readonly IMapper _mapper;

        public UserController(ILogger<AccountController> logger, IRepository<UserRepoModel> users, IRepository<RegistrantRepoModel> registrants, IMapper mapper)
        {
            _logger = logger;
            _users = users;
            _registrants = registrants;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsUser(int id)
        {
            var userRepo = _users.Get().FirstOrDefault(reg => reg.Id == id);
            var registrantRepo = userRepo.GetRegistrant(_registrants);

            var userModel = _mapper.Map<UserModel>(userRepo);
            userModel.Registrant = _mapper.Map<RegistrantModel>(registrantRepo);

            return View(userModel);
        }

        public IActionResult DisplayUsers()
        {
            var usersRepo = _users.Get().ToList();

            var usersModel = _mapper.Map<List<UserModel>>(usersRepo);

            return View(usersModel);
        }
    }
}