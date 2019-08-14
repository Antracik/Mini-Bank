using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Services.Models;
using System.Collections.Generic;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILogger<AccountController> logger, 
                                IUserService userService,
                                IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult DetailsUser(int id)
        {
            var userServiceModel = _userService.GetUserById(id, includeRegistrant: true);

            var userModel = _mapper.Map<UserModel>(userServiceModel);

            return View(userModel);
        }

        [HttpGet]
        public IActionResult DisplayUsers()
        {
            var userServiceModels = _userService.GetAllUsers();

            var userModels = _mapper.Map<List<UserModel>>(userServiceModels);

            return View(userModels);
        }

        [HttpGet]
        public IActionResult FilterUser(string email)
        {
            var userModelList = new List<UserModel>();

            var userServiceModel = _userService.GetUserByEmail(email);

            var userModel = _mapper.Map<UserModel>(userServiceModel);

            if (userModel != null)
            {
                userModelList.Add(userModel);
            }

            return View("DisplayUsers", userModelList);
        }

        [HttpGet]
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

            var userServiceModel = _mapper.Map<UserServiceModel>(item);

            int userId = _userService.CreateUser(userServiceModel);
            
            return RedirectToAction("DetailsUser", "User", new { id = userId });
        }

        [HttpGet("{id}")]
        public IActionResult EditUserView(int id)
        {
            var userServiceModel = _userService.GetUserById(id);

            var userModel = _mapper.Map<UserModel>(userServiceModel);

            return View(userModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditUserView", item);
            }

            var userServiceModel = _mapper.Map<UserServiceModel>(item);

            _userService.UpdateUser(userServiceModel);

            return RedirectToAction("DetailsUser", "User", new { id = item.Id });
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            if(!_userService.DeleteUser(id))
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete user with registrant" });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}