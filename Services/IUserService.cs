using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;

namespace Mini_Bank.Services
{
    public interface IUserService
    {
        UserDbRepoModel GetUserByEmail(string email);

        UserDbRepoModel GetUserById(int id, bool includeRegistrant = false);
        IEnumerable<UserDbRepoModel> GetAllUsers();

        /// <summary>
        /// Adds the user to the repository and returns the Id that he has been given
        /// </summary>
        /// <param name="user"></param>
        int CreateUser(UserModel user);
        void UpdateUser(UserModel user);
        bool DeleteUser(int id);
    }
}
