using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Bank.FileRepo.Models;

namespace Mini_Bank.Services
{
    public interface IUserService
    {
        UserRepoModel GetUserByEmail(string email);
    }
}
