using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Helpers
{
    public static class AdminSeeder
    {
        public static void SeedAdmin(UserManager<UserEntityModel> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                var admin = new UserEntityModel
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(admin, "Vengance1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }

            }

        }
    }
}
