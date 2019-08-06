using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models;
using Mini_Bank.Services;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Bank.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(ILogger<AccountController> logger, 
                            UnitOfWork unitOfWork,
                            IUserService userService,
                            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        
        [HttpGet("{id}")]
        public IActionResult DetailsUser(int id)
        {
            var userEntity = _userService.GetUserById(id, includeRegistrant: true);

            var userModel = _mapper.Map<UserModel>(userEntity);

            return View(userModel);
        }

        [HttpGet]
        public IActionResult DisplayUsers()
        {
            var userEntities = _userService.GetAllUsers();

            var userModels = _mapper.Map<List<UserModel>>(userEntities);

            return View(userModels);
        }

        [HttpGet]
        public IActionResult FilterUser(string email)
        {
            var userModelList = new List<UserModel>();

            var userEntity = _userService.GetUserByEmail(email);

            var userModel = _mapper.Map<UserModel>(userEntity);

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

            int userId = _userService.CreateUser(item);
            
            return RedirectToAction("DetailsUser", "User", new { id = userId });
        }

        [HttpGet("{id}")]
        public IActionResult EditUserView(int id)
        {
            var userEntity = _userService.GetUserById(id);

            var userModel = _mapper.Map<UserModel>(userEntity);

            return View(userModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditUserView", item);
            }

            _userService.UpdateUser(item);

            return RedirectToAction("DetailsUser", "User", new { id = item.Id });
        }

        //[HttpDelete]
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