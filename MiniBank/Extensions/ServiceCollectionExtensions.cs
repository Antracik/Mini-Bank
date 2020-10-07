using AutoMapper.Configuration;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MongoDb;
using Services.Services;
using Services.Services.Implementations;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Mini_Bank.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUserService), typeof(UserService))
                    .AddScoped(typeof(IRegistrantService), typeof(RegistrantService))
                    .AddScoped(typeof(IWalletService), typeof(WalletService))
                    .AddScoped(typeof(IAccountService), typeof(AccountService))
                    .AddScoped(typeof(INomenclatureService), typeof(NomenclatureService))
                    .AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>))
                    .AddScoped(typeof(IMongoLoggerService), typeof(MongoLoggerService))
                    .AddScoped(typeof(IDateService), typeof(DateService))
                    .AddScoped(typeof(IFileService), typeof(FileService))
                    .AddScoped(typeof(ICurrencyService), typeof(CurrencyService))
                    .AddScoped(typeof(IFinancialTransactionService), typeof(FinancialTransactionService))
                    .AddScoped(typeof(IDashboardService), typeof(DashboardService))
                    .AddScoped(typeof(IAdministrationService), typeof(AdministrationService))
                    .AddScoped(typeof(ITicketService), typeof(TicketService))
                    .AddScoped<UnitOfWork>();

            services.AddTransient(typeof(IEmailSender), typeof(EmailSender));

            return services;
        }


        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserEntityModel, RoleModel>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequireLowercase = true;   
                    options.Password.RequireUppercase = true;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<BankContext>()
                  .AddDefaultTokenProviders();

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setupAction =>
                {
                    setupAction.SwaggerDoc("MiniBankSpecification", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "MiniBank",
                        Version = "1"
                    });
                });

            return services;
        }

        public static IServiceCollection AddMongoDB(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration Configuration)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });

            services.AddTransient(typeof(IMongoRepository), typeof(MongoRepository));

            return services;
        }
    }
}
