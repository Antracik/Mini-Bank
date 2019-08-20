﻿using System;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Mini_Bank.Areas.Identity.IdentityHostingStartup))]
namespace Mini_Bank.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddSingleton(typeof(SignInManager<UserDbRepoModel>));
                //services.AddSingleton(typeof(IUserStore<UserDbRepoModel>));
                //services.AddSingleton(typeof(UserManager<UserDbRepoModel>));
            });
        }
    }
}