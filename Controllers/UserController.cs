using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
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
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(ILogger<AccountController> logger, 
                            UnitOfWork unitOfWork,
                            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        
        [HttpGet("{id}")]
        public IActionResult DetailsUser(int id)
        {
            var userModel = new UserModel();

            using(_unitOfWork.Add<UserDbRepoModel>().Add<RegistrantDbRepoModel>())
            {
                var userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().GetById(id);
                userModel = _mapper.Map<UserModel>(userEntity);

                var registrantEntity = _unitOfWork.GetRepository<RegistrantDbRepoModel>().GetById(userEntity.Id);

                userModel.Registrant = _mapper.Map<RegistrantModel>(registrantEntity);

            }

            return View(userModel);
        }

        [HttpGet]
        public IActionResult DisplayUsers()
        {
            var userModels = new List<UserModel>();

            using(_unitOfWork.Add<UserDbRepoModel>())
            {
                var userEntities = _unitOfWork.GetRepository<UserDbRepoModel>().Get();

                userModels = _mapper.Map<List<UserModel>>(userEntities);
            }

            return View(userModels);
        }

        [HttpGet]
        public IActionResult FilterUser(string email)
        {

            var userList = new List<UserModel>();

            using(_unitOfWork.Add<UserDbRepoModel>())
            {
                var userEntities = _unitOfWork.GetRepository<UserDbRepoModel>().Get(user => user.Email == email);

                if (userEntities != null)
                {
                    userList = _mapper.Map<List<UserModel>>(userEntities);
                }
            }

            return View("DisplayUsers", userList);
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

            var userEntity = new UserDbRepoModel();

            using(_unitOfWork.Add<UserDbRepoModel>())
            {
                userEntity = _mapper.Map<UserDbRepoModel>(item);

                _unitOfWork.GetRepository<UserDbRepoModel>().AddItem(userEntity);
                _unitOfWork.Save();
            }
            
            return RedirectToAction("DetailsUser", "User", new { id = userEntity.Id });
        }

        [HttpGet("{id}")]
        public IActionResult EditUserView(int id)
        {
            var userModel = new UserModel();

            using(_unitOfWork.Add<UserDbRepoModel>())
            {
                var userRepo = _unitOfWork.GetRepository<UserDbRepoModel>().GetById(id);

                userModel = _mapper.Map<UserModel>(userRepo);
            }

            return View(userModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserModel item)
        {
            if(!ModelState.IsValid)
            {
                return View("EditUserView", item);
            }

            using (_unitOfWork.Add<UserDbRepoModel>())
            {
                var userEntity = _mapper.Map<UserDbRepoModel>(item);
                _unitOfWork.GetRepository<UserDbRepoModel>().Update(userEntity);
                _unitOfWork.Save();
            }

            return RedirectToAction("DetailsUser", "User", new { id = item.Id });
        }

        //[HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            using (_unitOfWork.Add<UserDbRepoModel>().Add<RegistrantDbRepoModel>())
            {
                var userRepo = _unitOfWork.GetRepository<UserDbRepoModel>();

                var userEntity = userRepo.GetById(id);

                if(_unitOfWork.GetRepository<RegistrantDbRepoModel>()
                    .Get(reg => reg.UserId == userEntity.Id)
                    .FirstOrDefault() != null)
                {
                    return View("Error", new ErrorViewModel { RequestId = @"Can't delete user with registrant" });
                }

                userRepo.Delete(id);

                _unitOfWork.Save();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}