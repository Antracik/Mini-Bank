﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using Mini_Bank.Services;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Bank.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<UserRepoModel> _users;
        private readonly IRepository<RegistrantRepoModel> _registrants;
        private readonly IRepository<WalletRepoModel> _wallets;
        private readonly IRepository<AccountRepoModel> _accounts;
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(ILogger<AccountController> logger, 
                            IRepository<UserRepoModel> users, 
                            IRepository<WalletRepoModel> wallets,
                            IRepository<RegistrantRepoModel> registrants,
                            IRepository<AccountRepoModel> accounts,
                            IUserService userService,
                            IMapper mapper)
        {
            _logger = logger;
            _users = users;
            _registrants = registrants;
            _mapper = mapper;
            _wallets = wallets;
            _accounts = accounts;
            _userService = userService;
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

        public IActionResult FilterUser(string email)
        {
            var userRepo = _userService.GetUserByEmail(email);
            List<UserModel> userModelsList = new List<UserModel>();

            if (userRepo != null)
            {
                var userModel = _mapper.Map<UserModel>(userRepo);
                userModelsList.Add(userModel);
            }

            return View("DisplayUsers", userModelsList);
        }

        public IActionResult CreateUserView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel item)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUserView", item);
            }

            int NewUserId = _users.Get().Max(uID => uID.Id);
            NewUserId++;
            item.Id = NewUserId;

            var UserRepoModel = _mapper.Map<UserRepoModel>(item);
            _users.AddItem(UserRepoModel);
            _users.SaveChanges();
            
            return RedirectToAction("DetailsUser", "User", new { id = NewUserId });
        }

        public IActionResult EditUserView(int id)
        {
            var userRepo = _users.Get().FirstOrDefault(reg => reg.Id == id);
            
            var userModel = _mapper.Map<UserModel>(userRepo);

            return View(userModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditUserView", item);
            }

            var UserRepo = _mapper.Map<UserRepoModel>(item);

            _users.Replace(UserRepo);

            _users.SaveChanges();

            return RedirectToAction("DetailsUser", "User", new { id = item.Id });
        }

        public IActionResult DeleteUser(int id)
        {
            var userRepo = _users.Get().FirstOrDefault(user => user.Id == id);

            if(userRepo.GetRegistrant(_registrants) != null)
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete user with registrant" });
            }

            _users.Delete(id);
            _users.SaveChanges();

           return RedirectToAction("Index", "Home");
        }
    }
}