using AutoMapper;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mini_Bank.Middleware;
using Services.Models;
using System;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<BankContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("MiniBankDB")).EnableSensitiveDataLogging());
            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("MiniBankSpecification", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MiniBank",
                    Version = "1"
                });
            });
            services.AddScoped(typeof(IUserService),typeof(UserService));
            services.AddScoped(typeof(IRegistrantService), typeof(RegistrantService));
            services.AddScoped(typeof(IWalletService), typeof(WalletService));
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped(typeof(INomenclatureService), typeof(NomenclatureService));
            services.AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>));
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

            app.UseHttpsRedirection();
            app.UseRequestResponseLoggerMiddleware();
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
           {
               setupAction.SwaggerEndpoint("/swagger/MiniBankSpecification/swagger.json", "Mini Bank");
           });
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
