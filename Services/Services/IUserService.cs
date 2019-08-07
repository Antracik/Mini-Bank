using System.Collections.Generic;

namespace Services.Models
{
    public interface IUserService
    {
        UserServiceModel GetUserByEmail(string email);

        UserServiceModel GetUserById(int id, bool includeRegistrant = false);
        IEnumerable<UserServiceModel> GetAllUsers();

        /// <summary>
        /// Adds the user to the repository and returns the Id that he has been given
        /// </summary>
        /// <param name="user"></param>
        int CreateUser(UserServiceModel user);
        void UpdateUser(UserServiceModel user);
        bool DeleteUser(int id);
    }
}
