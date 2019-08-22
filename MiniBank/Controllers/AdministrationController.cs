using System;
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

namespace Mini_Bank.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {

        private readonly RoleManager<RoleModel> _roleManager;
        private readonly UserManager<UserDbRepoModel> _userManager;
        private readonly IMapper _mapper;

        public AdministrationController(RoleManager<RoleModel> roleManager,
                                        UserManager<UserDbRepoModel> userManager,
                                        IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
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

                IdentityResult result = await _roleManager.CreateAsync(roleModel);

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
        public IActionResult ListRoles()
        {

            var roles = _roleManager.Roles.ToList();

            var rolesViewModels = _mapper.Map<List<RoleViewModel>>(roles);

            return View(rolesViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            RoleModel role = await _roleManager.FindByIdAsync(Id);

            if(role == null)
            {
                return RedirectToAction("Error", new ErrorViewModel { RequestId = $@"Role with Id: {Id} not found" });
            }

            var editRole = _mapper.Map<EditRoleViewModel>(role);

            foreach(var user in _userManager.Users)
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    editRole.Users.Add(user.UserName);
                }
            }

            return View(editRole);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            int tempId = (int)TempData["id"];

            RoleModel role = await _roleManager.FindByIdAsync(tempId.ToString());

            if (role == null)
            {
                return RedirectToAction("Error","Error", new ErrorViewModel { RequestId = $@"Role with Id: {tempId.ToString()} not found" });
            }
            else
            {
                role.Name = model.Name;

                var result = await _roleManager.UpdateAsync(role);
                
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

            var role = await _roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $"No role with Id: {roleId} found" });
            }

            var models = new List<UserRoleViewModel>();

            foreach(var user in _userManager.Users.ToList())
            {
                var userRole = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if( await _userManager.IsInRoleAsync(user, role.Name))
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

            var role = await _roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                return RedirectToAction("Error", "Error", new ErrorViewModel { RequestId = $"No role with Id: {roleId} found" });
            }

            for(int i = 0; i < models.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(models[i].UserId.ToString());

                IdentityResult result;

                if(models[i].IsSelected && !(await _userManager.IsInRoleAsync(user,role.Name)))
                {
                   result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!models[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                   result = await _userManager.RemoveFromRoleAsync(user, role.Name);
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
    }
}