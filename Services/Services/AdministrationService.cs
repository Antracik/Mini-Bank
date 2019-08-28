using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;

namespace Services.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly UserManager<UserDbRepoModel> _userManager;
        private readonly RoleManager<RoleModel> _roleManager;
        private readonly UnitOfWork _unitOfWork;


        public AdministrationService(UserManager<UserDbRepoModel> userManager,
                                    RoleManager<RoleModel> roleManager,
                                    UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
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

        public IEnumerable<AllWalletsWithSums> GetAllWalletsWithSums(string orderBy, string filter)
        {
            var repo = _unitOfWork.Add<AllWalletsWithSums>().GetRepository<AllWalletsWithSums>();
            var allWalletsWithSums = new List<AllWalletsWithSums>();

            var rawSql = new AllWalletsWithSums().GetQuery();
            
            switch(orderBy)
            {
                case "Id":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderBy(y => y.Id)).ToList();
                    break;
                case "Id_desc":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderByDescending(y => y.Id)).ToList();
                    break;
                case "ClientName":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderBy(y => y.ClientName)).ToList();
                    break;
                case "ClientName_desc":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderByDescending(y => y.ClientName)).ToList();
                    break;
                case "ClientCountry":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderBy(y => y.ClientCountry)).ToList();
                    break;
                case "ClientCountry_desc":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderByDescending(y => y.ClientCountry)).ToList();
                    break;
                case "Balance":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderBy(y => y.Balance)).ToList();
                    break;
                case "Balance_desc":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderByDescending(y => y.Balance)).ToList();
                    break;
                case "Currency":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderBy(y => y.Currency)).ToList();
                    break;
                case "Currency_desc":
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderByDescending(y => y.Currency)).ToList();
                    break;
                default:
                    allWalletsWithSums = repo.FromSQL(rawSql, null, x => x.OrderBy(y => y.Id)).ToList();
                    break;
            }

            return allWalletsWithSums;
        }
    }
}
