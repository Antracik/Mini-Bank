using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Services.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly UserManager<UserDbRepoModel> _userManager;
        private readonly RoleManager<RoleModel> _roleManager;

        public AdministrationService(UserManager<UserDbRepoModel> userManager,
                                    RoleManager<RoleModel> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<IdentityResult> AddUserToRoleAsync(UserDbRepoModel user, string roleName)
        { 
            return _userManager.AddToRoleAsync(user, roleName);
        }

        public Task<IdentityResult> CreateRoleAsync(RoleModel role)
        {
            return _roleManager.CreateAsync(role);
        }

        public Task<RoleModel> FindRoleByIdAsync(string roleId)
        {
            return _roleManager.FindByIdAsync(roleId);
        }

        public Task<UserDbRepoModel> FindUserByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            return _roleManager.Roles;
        }

        public IEnumerable<UserDbRepoModel> GetUsers()
        {
            return _userManager.Users;
        }

        public Task<IList<UserDbRepoModel>> GetUsersInRoleAsync(string roleName)
        {
            return _userManager.GetUsersInRoleAsync(roleName);
        }

        public Task<bool> IsUserInRoleAsync(UserDbRepoModel user, string roleName)
        {
            return _userManager.IsInRoleAsync(user, roleName);
        }

        public Task<IdentityResult> RemoveUserFromRoleAsync(UserDbRepoModel user, string roleName)
        {
            return _userManager.RemoveFromRoleAsync(user, roleName);
        }

        public Task<IdentityResult> UpdateRoleAsync(RoleModel role)
        {
            return _roleManager.UpdateAsync(role);
        }
    }
}
