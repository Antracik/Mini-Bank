﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Services.Models;
using Services.Services;
using X.PagedList;

namespace Mini_Bank.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class AdministrationController : Controller
    {

        private readonly IAdministrationService _administraionService;
        private readonly IMapper _mapper;
        private readonly INomenclatureService _nomenclatureService;

        public AdministrationController(IAdministrationService administraionService, 
                                        IMapper mapper, 
                                        INomenclatureService nomenclatureService)
        {
            _administraionService = administraionService;
            _mapper = mapper;
            _nomenclatureService = nomenclatureService;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                RoleModel roleModel = new RoleModel
                {
                    Name = roleViewModel.Name
                };

                IdentityResult result = await _administraionService.CreateRoleAsync(roleModel);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(roleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListRoles()
        {
            var roles = _administraionService.GetRoles();

            var rolesViewModels = _mapper.Map<List<RoleViewModel>>(roles);

            foreach (var role in rolesViewModels)
            {
                var res = await _administraionService.GetUsersInRoleAsync(role.Name);
                role.TotalUsers = res.Count;
            }

            return View(rolesViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            RoleModel role = await _administraionService.FindRoleByIdAsync(Id);

            if(role == null)
            {
                return RedirectToAction("Error", new ErrorViewModel { RequestId = $@"Role with Id: {Id} not found" });
            }

            var editRole = _mapper.Map<EditRoleViewModel>(role);

            foreach(var user in _administraionService.GetUsers())
            {
                if(await _administraionService.IsUserInRoleAsync(user, role.Name))
                {
                    editRole.Users.Add(user.Email);
                }
            }

            return View(editRole);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            int tempId = (int)TempData["id"];

            RoleModel role = await _administraionService.FindRoleByIdAsync(tempId.ToString());

            if (role == null)
            {
                return RedirectToAction("Error","Error", new ErrorViewModel { RequestId = $@"Role with Id: {tempId.ToString()} not found" });
            }
            else
            {
                role.Name = model.Name;

                var result = await _administraionService.UpdateRoleAsync(role);
                
                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                //Something went wrong, put Id back in TempData
                TempData["id"] = tempId;

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _administraionService.FindRoleByIdAsync(roleId);

            if(role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $"No role with Id: {roleId} found" });
            }

            var models = new List<UserRoleViewModel>();

            foreach(var user in _administraionService.GetUsers())
            {
                var userRole = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.Email
                };

                if( await _administraionService.IsUserInRoleAsync(user, role.Name))
                {
                    userRole.IsSelected = true;
                }
                else
                {
                    userRole.IsSelected = false;
                }

                models.Add(userRole);
            }

            TempData["roleId"] = roleId;

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> models)
        {
            string roleId = TempData["roleId"].ToString();

            var role = await _administraionService.FindRoleByIdAsync(roleId);

            if(role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $"No role with Id: {roleId} found" });
            }

            for(int i = 0; i < models.Count; i++)
            {
                var user = await _administraionService.FindUserByIdAsync(models[i].UserId.ToString());

                IdentityResult result;

                if(models[i].IsSelected && !(await _administraionService.IsUserInRoleAsync(user,role.Name)))
                {
                   result = await _administraionService.AddUserToRoleAsync(user, role.Name);
                }
                else if(!models[i].IsSelected && await _administraionService.IsUserInRoleAsync(user, role.Name))
                {
                   result = await _administraionService.RemoveUserFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if(result.Succeeded)
                {
                    if( i < (models.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", "Administration", new { Id = roleId });
                    }
                }
            }

            //If empty go back to edit role
            return RedirectToAction("EditRole", "Administration", new { Id = roleId });
        }

        [HttpGet]
        public IActionResult AllWalletsWithSums(AllWalletsWithSumsViewModel model, string prevFilters, string sortBy = "", int pageIndex = 1)
        {
            var countries = _mapper.Map<List<CountryModel>>(_nomenclatureService.GetCountries()).OrderBy(x => x.Name).ToList();

            pageIndex = pageIndex > 0 ? pageIndex : 1;

            model.Countries = countries;
            model.CurrentPage = pageIndex;
            model.CurrentSort = sortBy;
           
            if(prevFilters != null)
            {
                model.Filters = JsonConvert.DeserializeObject<AllWalletsWithSumsFilters>(prevFilters);
            }

            model.IdSort = sortBy.Equals("Id") ? "Id_desc" : "Id";
            model.ClientNameSort = sortBy.Equals("ClientName") ? "ClientName_desc" : "ClientName";
            model.ClientCountrySort = sortBy.Equals("ClientCountry") ? "ClientCountry_desc" : "ClientCountry";
            model.BalanceSort = sortBy.Equals("Balance") ? "Balance_desc" : "Balance";
            model.CurrencySort = sortBy.Equals("Currency") ? "Currency_desc" : "Currency";

            var filterServiceModel = _mapper.Map<AllWalletsWithSumsFiltersServiceModel>(model.Filters);

            var test = _administraionService.GetAllWalletsWithSums(sortBy, filterServiceModel);

            model.Data = test.ToPagedList(pageIndex, 10);

            return View(model);
        }
       
    }
}