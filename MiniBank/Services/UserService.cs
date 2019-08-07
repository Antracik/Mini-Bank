using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mini_Bank.DbRepo;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models;

namespace Mini_Bank.Services
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

        public int CreateUser(UserModel user)
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

        public IEnumerable<UserDbRepoModel> GetAllUsers()
        {
            var userEntities = new List<UserDbRepoModel>();

            _unitOfWork.Add<UserDbRepoModel>();
            
            userEntities = _unitOfWork.GetRepository<UserDbRepoModel>().Get().ToList();

            return userEntities;
        }

        public UserDbRepoModel GetUserByEmail(string email)
        {
            _unitOfWork.Add<UserDbRepoModel>();
            
            var userEntity = _unitOfWork.GetRepository<UserDbRepoModel>().Get(user => user.Email == email).FirstOrDefault();
            
            return userEntity;
        }

        public UserDbRepoModel GetUserById(int id, bool includeRegistrant = false)
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

            return userEntity;
        }

        public void UpdateUser(UserModel user)
        {
            _unitOfWork.Add<UserDbRepoModel>();
            
            var userEntity = _mapper.Map<UserDbRepoModel>(user);
            _unitOfWork.GetRepository<UserDbRepoModel>().Update(userEntity);
            _unitOfWork.Save();
            
        }

    }
}
