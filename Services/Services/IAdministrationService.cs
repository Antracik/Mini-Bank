using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IAdministrationService
    {
        IEnumerable<RoleModel> GetRoles();
        IEnumerable<UserDbRepoModel> GetUsers();
        Task<RoleModel> FindRoleByIdAsync(string roleId);
        Task<UserDbRepoModel> FindUserByIdAsync(string userId);
        Task<bool> IsUserInRoleAsync(UserDbRepoModel user, string roleName);
        Task<IList<UserDbRepoModel>> GetUsersInRoleAsync(string roleName);
        Task<IdentityResult> CreateRoleAsync(RoleModel role);
        Task<IdentityResult> UpdateRoleAsync(RoleModel role);
        Task<IdentityResult> AddUserToRoleAsync(UserDbRepoModel user, string roleName);
        Task<IdentityResult> RemoveUserFromRoleAsync(UserDbRepoModel user, string roleName);
        IEnumerable<AllWalletsWithSums> GetAllWalletsWithSums(string orderBy, string filter);
    }
}
