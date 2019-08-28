using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.Models;
using Services.Models;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Mini_Bank.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
                                IMapper mapper)
        {
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult DisplayUsers(string filterEmail, string sortBy = "", int pageIndex = 1)
        {
            var userServiceModels = _userService.GetAllUsers();

            ViewBag.FilterEmail = filterEmail;
            ViewBag.CurrentSort = sortBy;
            ViewBag.CurrentPage = pageIndex;

            ViewBag.IdSort = sortBy.Equals("Id") ? "Id_desc" : "Id";
            ViewBag.DateCreatedSort = sortBy.Equals("DateCreated") ? "DateCreated_desc" : "DateCreated";
            ViewBag.EmailConfirmedSort = sortBy.Equals("EmailConfirmed") ? "EmailConfirmed_desc" : "EmailConfirmed";
            ViewBag.EmailSort = sortBy.Equals("Email") ? "Email_desc" : "Email";

            if (!string.IsNullOrEmpty(filterEmail))
            {
                userServiceModels = userServiceModels.Where(x => x.Email.ToUpper().Contains(filterEmail.ToUpper()));
            }

            switch (sortBy)
            {
                case "Id":
                    userServiceModels = userServiceModels.OrderBy(x => x.Id).ToList();
                    break;
                case "Id_desc":
                    userServiceModels = userServiceModels.OrderByDescending(x => x.Id).ToList();
                    break;
                case "DateCreated":
                    userServiceModels = userServiceModels.OrderBy(x => x.DateCreated).ToList();
                    break;
                case "DateCreated_desc":
                    userServiceModels = userServiceModels.OrderByDescending(x => x.DateCreated).ToList();
                    break;
                case "EmailConfirmed":
                    userServiceModels = userServiceModels.OrderBy(x => x.EmailConfirmed).ToList();
                    break;
                case "EmailConfirmed_desc":
                    userServiceModels = userServiceModels.OrderByDescending(x => x.EmailConfirmed).ToList();
                    break;
                case "Email":
                    userServiceModels = userServiceModels.OrderBy(x => x.Email).ToList();
                    break;
                case "Email_desc":
                    userServiceModels = userServiceModels.OrderByDescending(x => x.Email).ToList();
                    break;
                default:
                    userServiceModels = userServiceModels.OrderBy(x => x.Id).ToList();
                    break;
            }

            var userModels = _mapper.Map<List<UserModel>>(userServiceModels);

            var pagedModels = userModels.ToPagedList(pageIndex, 10);

            return View(pagedModels);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CreateUserView()
        {
            return RedirectPermanent("../../Identity/Account/Register");
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel item)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("CreateUserView", item);
            //}

            //var userServiceModel = _mapper.Map<UserServiceModel>(item);

            //int userId = _userService.CreateUser(userServiceModel);

            //return RedirectToAction("DetailsUser", "User", new { id = userId });

            return RedirectPermanent("../../Identity/Account/Register");
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
            if (!ModelState.IsValid)
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
            if (!_userService.DeleteUser(id))
            {
                return View("Error", new ErrorViewModel { RequestId = @"Can't delete user with registrant" });
            }

            return RedirectToAction("Index", "Home");
        }
    }
}