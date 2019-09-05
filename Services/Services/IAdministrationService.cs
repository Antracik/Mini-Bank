using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Services
{
    public interface IAdministrationService
    {
        IEnumerable<RoleModel> GetRoles();
        IEnumerable<UserEntityModel> GetUsers();
        Task<RoleModel> FindRoleByIdAsync(string roleId);
        Task<UserEntityModel> FindUserByIdAsync(string userId);
        Task<bool> IsUserInRoleAsync(UserEntityModel user, string roleName);
        Task<IList<UserEntityModel>> GetUsersInRoleAsync(string roleName);
        Task<IdentityResult> CreateRoleAsync(RoleModel role);
        Task<IdentityResult> UpdateRoleAsync(RoleModel role);
        Task<IdentityResult> AddUserToRoleAsync(UserEntityModel user, string roleName);
        Task<IdentityResult> RemoveUserFromRoleAsync(UserEntityModel user, string roleName);
        IEnumerable<AllWalletsWithSums> GetAllWalletsWithSums(string orderBy, AllWalletsWithSumsFiltersServiceModel filters);
    }
}
