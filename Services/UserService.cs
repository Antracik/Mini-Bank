using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;

namespace Mini_Bank.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserRepoModel> _users;

        public UserService(IRepository<UserRepoModel> users)
        {
            _users = users;
        }

        public UserRepoModel GetUserByEmail(string email)
        {
           return _users.Get().FirstOrDefault(user => user.Email.Equals(email));
        }
    }
}
