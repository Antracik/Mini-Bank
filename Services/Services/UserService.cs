using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Services.Models;
using Services.Services;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserDbRepoModel> _userManager;
        private readonly RoleManager<RoleModel> _roleManager;
        private readonly IDateService _dateService;

        public UserService(UnitOfWork unitOfWork, IMapper mapper, IDateService dateService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            var userStore = new UserStore<UserDbRepoModel, RoleModel, BankContext, int>(_unitOfWork.BankContext) { AutoSaveChanges = false };

            var roleStore = new RoleStore<RoleModel, BankContext, int>(_unitOfWork.BankContext) { AutoSaveChanges = false };

            var test = roleStore.Roles.ToList();

            _dateService = dateService;
        }

        public int CreateUser(UserServiceModel user)
        {
            _unitOfWork.Add<UserDbRepoModel>();

            var userEntity = _mapper.Map<UserDbRepoModel>(user);

            _dateService.SetDateCreatedNow(ref userEntity);

            _unitOfWork.GetRepository<UserDbRepoModel>().AddItem(userEntity);
            _unitOfWork.Save();

            return userEntity.Id;
        }

        public bool DeleteUser(int id)
        {
            _unitOfWork.Add<UserDbRepoModel>();
            
            var userRepo = _unitOfWork.GetRepository<UserDbRepoModel>();

            var userEntity = userRepo.Get(user => user.Id == id, null, "Registrant").FirstOrDefault();

            if ( userEntity.Registrant != null)
            {
                return false;
            }

            userRepo.Delete(id);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            _unitOfWork.Add<UserDbRepoModel>();
            
            var userEntities = _unitOfWork.GetRepository<UserDbRepoModel>().Get().ToList();

            var userModels = _mapper.Map<List<UserServiceModel>>(userEntities);

            return userModels;
        }

        public UserServiceModel GetUserByEmail(string email)
        {
            _unitOfWork.Add<UserDbRepoModel>();
            
            var userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().Get(user => user.Email == email).FirstOrDefault();

            var userModel = _mapper.Map<UserServiceModel>(userEntity);

            return userModel;
        }

        public UserServiceModel GetUserById(int id, bool includeRegistrant = false)
        {
            var userEntity = new UserDbRepoModel();

            _unitOfWork.Add<UserDbRepoModel>();
            
            if(includeRegistrant)
            {
                userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().Get(user => user.Id == id, null, "Registrant").FirstOrDefault();
            }
            else
            {
                userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().GetById(id);
            }

            var userModel = _mapper.Map<UserServiceModel>(userEntity);

            return userModel; 
        }

        public void UpdateUser(UserServiceModel user)
        {
            _unitOfWork.Add<UserDbRepoModel>();
            
            var userEntity = _mapper.Map<UserDbRepoModel>(user);

            _dateService.SetDateEditedNow(ref userEntity);

            _unitOfWork.GetRepository<UserDbRepoModel>().Update(userEntity);
            _unitOfWork.Save();
            
        }

    }
}
