﻿using AutoMapper;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mini_Bank.Hubs;
using Mini_Bank.Middleware;
using MongoDb;
using Services.Services;
using Services.Services.Implementations;
using Shared;
using System;
using System.IO;
using X.PagedList.Mvc.Common;

namespace Mini_Bank
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //var connection = @"Server=DT-VN00321\PPANAYOTOV;Database=Mini_Bank;Trusted_Connection=True;ConnectRetryCount=0";

            // register services at Startup
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddNodeServices();

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddDbContext<BankContext>
                (options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MiniBankDB"), b => b.MigrationsAssembly("Mini Bank")).EnableSensitiveDataLogging();
                });

            services.AddIdentity<UserEntityModel, RoleModel>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.SignIn.RequireConfirmedEmail = false; // REMEMBER TO CHANGE !!!!
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BankContext>()
              .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddAuthentication()
                    .AddGoogle(options => 
                    {
                        IConfigurationSection googleAuthNSection =
                            Configuration.GetSection("Authentication:Google");

                        options.ClientId = googleAuthNSection["ClientId"];
                        options.ClientSecret = googleAuthNSection["ClientSecret"];
                    });

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("MiniBankSpecification", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MiniBank",
                    Version = "1"
                });
            });

            services.AddSignalR();

            services.AddScoped(typeof(IUserService),typeof(UserService));
            services.AddScoped(typeof(IRegistrantService), typeof(RegistrantService));
            services.AddScoped(typeof(IWalletService), typeof(WalletService));
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped(typeof(INomenclatureService), typeof(NomenclatureService));
            services.AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>));
            services.AddScoped(typeof(IMongoLoggerService),typeof(MongoLoggerService));
            services.AddScoped(typeof(IDataSeedService), typeof(DataSeedService));
            services.AddScoped(typeof(IDateService), typeof(DateService));
            services.AddScoped(typeof(IFileService), typeof(FileService));
            services.AddScoped(typeof(ICurrencyService), typeof(CurrencyService));
            services.AddScoped(typeof(IFinancialTransactionService), typeof(FinancialTransactionService));
            services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
            services.AddTransient(typeof(IEmailSender), typeof(EmailSender));
            services.AddTransient(typeof(IMongoRepository), typeof(MongoRepository));
            services.AddScoped(typeof(IAdministrationService), typeof(AdministrationService));
            // services.AddSingleton(typeof(IRepository<>), typeof(FileRepository<>));
            services.AddScoped<UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //string path = Environment.GetEnvironmentVariable("PATH");

            //path += @";" + Path.Combine(Environment.CurrentDirectory, "nodejs");
            //Environment.SetEnvironmentVariable("PATH", path);

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
           {
               setupAction.SwaggerEndpoint("/swagger/MiniBankSpecification/swagger.json", "Mini Bank");
           });
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            //app.UseRequestResponseLoggerMiddleware();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

                routes.MapRoute(
                   name: "Identity",
                   template: "{area:exists}/{controller=Account}/{action=Login}");
            });
        }
    }
}
