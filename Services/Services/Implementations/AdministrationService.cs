using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;
using Services.Models;

namespace Services.Services.Implementations
{
    public class AdministrationService : IAdministrationService
    {
        private readonly UserManager<UserEntityModel> _userManager;
        private readonly RoleManager<RoleModel> _roleManager;
        private readonly UnitOfWork _unitOfWork;


        public AdministrationService(UserManager<UserEntityModel> userManager,
                                    RoleManager<RoleModel> roleManager,
                                    UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> AddUserToRoleAsync(UserEntityModel user, string roleName)
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

        public Task<UserEntityModel> FindUserByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            return _roleManager.Roles;
        }

        public IEnumerable<UserEntityModel> GetUsers()
        {
            return _userManager.Users;
        }

        public Task<IList<UserEntityModel>> GetUsersInRoleAsync(string roleName)
        {
            return _userManager.GetUsersInRoleAsync(roleName);
        }

        public Task<bool> IsUserInRoleAsync(UserEntityModel user, string roleName)
        {
            return _userManager.IsInRoleAsync(user, roleName);
        }

        public Task<IdentityResult> RemoveUserFromRoleAsync(UserEntityModel user, string roleName)
        {
            return _userManager.RemoveFromRoleAsync(user, roleName);
        }

        public Task<IdentityResult> UpdateRoleAsync(RoleModel role)
        {
            return _roleManager.UpdateAsync(role);
        }

        public IEnumerable<AllWalletsWithSums> GetAllWalletsWithSums(string orderBy, AllWalletsWithSumsFiltersServiceModel filters)
        {
            var repo = _unitOfWork.Add<AllWalletsWithSums>().GetRepository<AllWalletsWithSums>();
            var allWalletsWithSums = new List<AllWalletsWithSums>();
            var rawSql = new AllWalletsWithSums().GetQuery();

            if (filters != null)
            {
                DateTime dateFrom, dateTo;
                IEnumerable<AllWalletsWithSums> query = new List<AllWalletsWithSums>();

                if (filters.Countries.Any())
                    query = repo.FromSQL(rawSql, x => filters.Countries.Any(y => filters.Countries.Contains(x.ClientCountry)));

                if (!query.Any())
                    query = repo.FromSQL(rawSql);

                if (DateTime.TryParseExact(filters.RegisteredFrom, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateFrom)
                    && DateTime.TryParseExact(filters.RegisteredTo, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTo))
                {
                    query = query.Where(x => x.Date >= dateFrom && x.Date <= dateTo);
                }

                allWalletsWithSums = query.ToList();
            }
            else
            {
                allWalletsWithSums = repo.FromSQL(rawSql).ToList();
            }

            switch(orderBy)
            {
                case "Id":
                    allWalletsWithSums = allWalletsWithSums.OrderBy(y => y.Id).ToList();
                    break;
                case "Id_desc":
                    allWalletsWithSums = allWalletsWithSums.OrderByDescending(y => y.Id).ToList();
                    break;
                case "ClientName":
                    allWalletsWithSums = allWalletsWithSums.OrderBy(y => y.ClientName).ToList();
                    break;
                case "ClientName_desc":
                    allWalletsWithSums = allWalletsWithSums.OrderByDescending(y => y.ClientName).ToList();
                    break;
                case "ClientCountry":
                    allWalletsWithSums = allWalletsWithSums.OrderBy(y => y.ClientCountry).ToList();
                    break;
                case "ClientCountry_desc":
                    allWalletsWithSums = allWalletsWithSums.OrderByDescending(y => y.ClientCountry).ToList();
                    break;
                case "Balance":
                    allWalletsWithSums = allWalletsWithSums.OrderBy(y => y.Balance).ToList();
                    break;
                case "Balance_desc":
                    allWalletsWithSums = allWalletsWithSums.OrderByDescending(y => y.Balance).ToList();
                    break;
                case "Currency":
                    allWalletsWithSums = allWalletsWithSums.OrderBy(y => y.Currency).ToList();
                    break;
                case "Currency_desc":
                    allWalletsWithSums = allWalletsWithSums.OrderByDescending(y => y.Currency).ToList();
                    break;
                default:
                    allWalletsWithSums = allWalletsWithSums.OrderBy(y => y.Id).ToList();
                    break;
            }

            return allWalletsWithSums;
        }
    }
}
