using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Data;
using Data.Entities;

namespace Services.Models
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int CreateUser(UserServiceModel user)
        {
            _unitOfWork.Add<UserDbRepoModel>();

            var userEntity = _mapper.Map<UserDbRepoModel>(user);

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

            userEntity.DateEdited = DateTime.Now;

            _unitOfWork.GetRepository<UserDbRepoModel>().Update(userEntity);
            _unitOfWork.Save();
            
        }

    }
}
