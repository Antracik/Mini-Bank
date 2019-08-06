﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models.EnumModels;
using Mini_Bank.Models.ViewModels;

namespace Mini_Bank.DbContexts
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public DbSet<UserDbRepoModel> Users { get; set; }
        public DbSet<RegistrantDbRepoModel> Registrants { get; set; }
        public DbSet<WalletDbRepoModel> Wallets { get; set; }
        public DbSet<AccountDbRepoModel> Accounts { get; set; }
        public DbSet<CurrencyModel> Currency { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<StatusModel> Status { get; set; }

    }
}