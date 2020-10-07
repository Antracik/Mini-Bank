using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;

namespace Data
{
    public class BankContext : IdentityDbContext<UserEntityModel, RoleModel, int>
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        //------------------- Tables -------------------//

        //******************* Nomenclature *************//
        public DbSet<CurrencyEntityModel> Currency { get; set; }
        public DbSet<CountryEntityModel> Countries { get; set; }
        public DbSet<TransactionTypeEntityModel> TransactionType { get; set; }
        public DbSet<TicketTypeEntityModel> TicketType { get; set; }
        public DbSet<TicketStatusEntityModel> TicketStatus { get; set; }
        //**********************************************//

        public DbSet<RegistrantEntityModel> Registrants { get; set; }
        public DbSet<WalletEntityModel> Wallets { get; set; }
        public DbSet<AccountEntityModel> Accounts { get; set; }
        public DbSet<StatusEntityModel> Status { get; set; }
        public DbSet<TransactionEntityModel> Transaction { get; set; }
        public DbSet<FileDescriptorEntityModel> Descriptor { get; set; }
        public DbSet<FileEntityModel> File { get; set; }
        public DbSet<CurrencyExchangeEntityModel> CurrencyExchange { get; set; }
        public DbSet<TicketEntityModel> Ticket { get; set; }
        public DbSet<TicketMessageEntityModel> TicketMessage { get; set; }

        //------------------- Queries -------------------//
        public DbQuery<AllWalletsWithSums> AllWalletsWithSumsQuery { get; set; }
        public DbQuery<UserTotalMoneyByCurrency> UserTotalMoneyByCurrencyQuery { get; set; }
        public DbQuery<TotalMoneyInBankByCurrency> TotalMoneyInBankByCurrencyQuery { get; set; }
        public DbQuery<NewUsersIn30Days> NewUsersIn30DaysQuery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CurrencyExchangeEntityModel>()
                .HasOne(x => x.FromCurrency)
                .WithMany()
                .HasForeignKey(m => m.FromCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurrencyExchangeEntityModel>()
                .HasOne(x => x.ToCurrency)
                .WithMany()
                .HasForeignKey(m => m.ToCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistrantEntityModel>()
                .HasOne(x => x.User)
                .WithOne(x => x.Registrant)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntityModel>()
                .HasOne(x => x.Registrant)
                .WithOne(i => i.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WalletEntityModel>()
                .HasOne(x => x.Registrant)
                .WithMany(x => x.Wallets)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountEntityModel>()
                .HasOne(x => x.Wallet)
                .WithMany(i => i.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntityModel>()
                .HasOne(x => x.CreatedByUser)
                .WithMany()
                .HasForeignKey(m => m.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntityModel>()
                .HasOne(x => x.EditedByUser)
                .WithMany()
                .HasForeignKey(m => m.EditedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistrantEntityModel>()
               .HasOne(x => x.CreatedByUser)
               .WithMany()
               .HasForeignKey(m => m.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistrantEntityModel>()
               .HasOne(x => x.EditedByUser)
               .WithMany()
               .HasForeignKey(m => m.EditedById)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransactionEntityModel>()
                .HasOne(x => x.Currency)
                .WithMany()
                .HasForeignKey(m => m.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryEntityModel>()
                 .HasData(
                 new CountryEntityModel { Id = 1, Name = CountryEnum.Countries.Bulgaria.ToString() },
                 new CountryEntityModel { Id = 2, Name = CountryEnum.Countries.Romania.ToString() },
                 new CountryEntityModel { Id = 3, Name = CountryEnum.Countries.Germany.ToString() },
                 new CountryEntityModel { Id = 4, Name = CountryEnum.Countries.Greece.ToString() },
                 new CountryEntityModel { Id = 5, Name = CountryEnum.Countries.England.ToString() },
                 new CountryEntityModel { Id = 6, Name = CountryEnum.Countries.France.ToString() },
                 new CountryEntityModel { Id = 7, Name = CountryEnum.Countries.Italy.ToString() }
                 );

            modelBuilder.Entity<RoleModel>()
                .HasData(
                new RoleModel { Id = 1, Name = "Basic", NormalizedName = "BASIC" },
                new RoleModel { Id = 2, Name = "Admin", NormalizedName = "ADMIN" }
                );

            modelBuilder.Entity<StatusEntityModel>()
                .HasData(
                    new StatusEntityModel
                    {
                        Id = 1,
                        Name = StatusEnum.Status.Okay.ToString()
                    },
                    new StatusEntityModel
                    {
                        Id = 2,
                        Name = StatusEnum.Status.Blocked.ToString()
                    }
                );

            modelBuilder.Entity<CurrencyEntityModel>()
                .HasData(
                    new CurrencyEntityModel { Id = 1, Name = CurrencyEnum.Currency.BGN.ToString() },
                    new CurrencyEntityModel { Id = 2, Name = CurrencyEnum.Currency.USD.ToString() },
                    new CurrencyEntityModel { Id = 3, Name = CurrencyEnum.Currency.GBP.ToString() }
                );

            modelBuilder.Entity<CurrencyExchangeEntityModel>()
                .HasData(
                new CurrencyExchangeEntityModel { Id = 1, FromCurrencyId = (int)CurrencyEnum.Currency.BGN, ToCurrencyId = (int)CurrencyEnum.Currency.USD, Rate = 0.60d },
                new CurrencyExchangeEntityModel { Id = 2, FromCurrencyId = (int)CurrencyEnum.Currency.BGN, ToCurrencyId = (int)CurrencyEnum.Currency.GBP, Rate = 0.46d },
                new CurrencyExchangeEntityModel { Id = 3, FromCurrencyId = (int)CurrencyEnum.Currency.GBP, ToCurrencyId = (int)CurrencyEnum.Currency.USD, Rate = 1.29d }
                );

            modelBuilder.Entity<TicketStatusEntityModel>()
                .HasData(
                new TicketStatusEntityModel { Id = 1, Name = TicketStatusEnum.TicketStatus.Open.ToString()},
                new TicketStatusEntityModel { Id = 2, Name = TicketStatusEnum.TicketStatus.Closed.ToString()}
                );

            modelBuilder.Entity<TransactionTypeEntityModel>()
                .HasData(
                new TransactionTypeEntityModel { Id = 1, Name = TransactionTypeEnum.TransactionType.Debit.ToString() },
                new TransactionTypeEntityModel { Id = 2, Name = TransactionTypeEnum.TransactionType.Credit.ToString() }
                );

            modelBuilder.Entity<TicketTypeEntityModel>()
                .HasData(
                new TicketTypeEntityModel { Id = 1, Name = TicketTypeEnum.TicketType.Finances.ToString()},
                new TicketTypeEntityModel { Id = 2, Name = TicketTypeEnum.TicketType.Wallets.ToString()},
                new TicketTypeEntityModel { Id = 3, Name = TicketTypeEnum.TicketType.Other.ToString()}
                );

            int num = 1;
            modelBuilder.Entity<UserEntityModel>()
                .HasData(
                    new UserEntityModel { Id = 1, Email = "preslav.miroslavov@gmail.com", NormalizedEmail = "PRESLAV.MIROSLAVOV@GMAIL.COM", NormalizedUserName = "PRESLAVPANAIOTOV", UserName = "PreslavPanaiotov", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 2, Email = "stefan.dimitrov@abv.bg", UserName = "StefanDimitrov", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 3, Email = "petar.marchev@mail.bg", UserName = "PetarMarchev", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 4, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 5, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 6, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 7, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 8, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 9, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 10, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 11, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 12, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 13, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 14, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 15, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 16, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 17, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 18, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 19, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 20, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now },
                    new UserEntityModel { Id = 21, Email = $"test{num++}@gmail.com", DateCreated = DateTime.Now }
                );

            num = 1;
            modelBuilder.Entity<RegistrantEntityModel>()
                .HasData(
                    new RegistrantEntityModel { Id = 1, FirstName = "Preslav", LastName = "Panayotov", Country = (int)CountryEnum.Countries.Bulgaria, Address = "ul. Street 42", UserId = 1, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 2, FirstName = "Stefan", LastName = "Dimitrov", Country = (int)CountryEnum.Countries.Germany, Address = "8-mi Primorski", UserId = 2, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 3, FirstName = "Petar", LastName = "Marchev", Country = (int)CountryEnum.Countries.France, Address = "Liberman 12", UserId = 3, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 4, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.Bulgaria, Address = $"Test{num++}", UserId = 4, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 5, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.Germany, Address = $"Test{num++}", UserId = 5, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 6, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 6, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 7, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 7, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 8, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 8, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 9, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 9, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 10, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 10, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 11, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 11, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 12, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 12, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 13, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 13, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 14, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 14, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 15, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 15, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 16, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 16, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 17, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 17, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 18, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 18, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 19, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 19, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 20, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 20, DateCreated = DateTime.Now },
                    new RegistrantEntityModel { Id = 21, FirstName = $"Test{num++}", LastName = $"Test{num++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{num++}", UserId = 21, DateCreated = DateTime.Now }
                );


            Random rand = new Random();
            num = 1;
            modelBuilder.Entity<WalletEntityModel>()
                .HasData(
                    new WalletEntityModel { Id = num++, Number = 4188, RegistrantId = 1, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 948, RegistrantId = 1, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 9809, RegistrantId = 1, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 9458, RegistrantId = 2, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 1889, RegistrantId = 2, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 6703, RegistrantId = 2, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 9890, RegistrantId = 3, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 1018, RegistrantId = 3, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = 9066, RegistrantId = 3, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 4, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 4, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 4, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 5, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 5, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 5, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 6, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 6, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 6, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 7, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 7, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 7, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 8, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 8, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 8, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 9, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 9, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 9, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 10, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 10, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 10, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 11, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 11, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 11, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 12, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 12, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 12, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 13, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 13, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 13, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 14, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 14, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 14, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 15, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 15, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 15, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 16, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 16, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 16, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 17, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 17, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 17, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 18, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 18, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 18, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 19, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 19, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 19, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 20, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 20, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 20, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 21, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 21, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now },
                    new WalletEntityModel { Id = num++, Number = rand.Next(1000, 9999), RegistrantId = 21, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked, DateCreated = DateTime.Now }
               );

            num = 1;
            modelBuilder.Entity<AccountEntityModel>()
                .HasData(
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 1, IBAN = "BG27TTBB94008486163628", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 1, IBAN = "BG77TTBB94006739924496", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 1, IBAN = "BG82BNPA94402678339673", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 2, IBAN = "BG11TTBB94009636993256", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 2, IBAN = "BG84IORT80944383911889", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 2, IBAN = "BG30STSA93001743638279", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 3, IBAN = "BG61TTBB94002569752388", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 3, IBAN = "BG79BNPA94401326493795", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 3, IBAN = "BG71BNPA94403364212612", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 4, IBAN = "BE98798249248593", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 4, IBAN = "BE39519894248419", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 4, IBAN = "BE51999467219162", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 5, IBAN = "BE27812249819173", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 5, IBAN = "BE86549411157550", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 5, IBAN = "BE45999614884989", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 6, IBAN = "BE08735678488413", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 6, IBAN = "BE80978224831777", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 6, IBAN = "BE59549568634626", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 7, IBAN = "DE73500105172747763277", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 7, IBAN = "DE73500105175222722351", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 7, IBAN = "DE19500105179421415465", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 8, IBAN = "DE09500105171626724371", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 8, IBAN = "DE85500105175574577219", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 8, IBAN = "DE66500105177765152229", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 9, IBAN = "DE69500105171238446744", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 9, IBAN = "DE69500105171238446744", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 9, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 10, IBAN = "BG27TTBB94008486163628", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 10, IBAN = "BG77TTBB94006739924496", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 10, IBAN = "BG82BNPA94402678339673", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 11, IBAN = "BG11TTBB94009636993256", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 11, IBAN = "BG84IORT80944383911889", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 11, IBAN = "BG30STSA93001743638279", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 12, IBAN = "BG61TTBB94002569752388", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 12, IBAN = "BG79BNPA94401326493795", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 12, IBAN = "BG71BNPA94403364212612", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 13, IBAN = "BE98798249248593", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 13, IBAN = "BE39519894248419", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 13, IBAN = "BE51999467219162", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 14, IBAN = "BE27812249819173", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 14, IBAN = "BE86549411157550", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 14, IBAN = "BE45999614884989", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 15, IBAN = "BE08735678488413", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 15, IBAN = "BE80978224831777", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 15, IBAN = "BE59549568634626", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 16, IBAN = "DE73500105172747763277", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 16, IBAN = "DE73500105175222722351", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 16, IBAN = "DE19500105179421415465", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 17, IBAN = "DE09500105171626724371", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 17, IBAN = "DE85500105175574577219", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 17, IBAN = "DE66500105177765152229", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 18, IBAN = "DE69500105171238446744", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 18, IBAN = "DE69500105171238446744", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 18, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 19, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 19, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 19, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 20, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 20, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 20, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 21, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 21, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 21, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 22, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 22, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 22, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 23, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 23, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 23, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 24, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 24, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 24, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 25, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 25, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 25, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 26, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 26, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 26, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 27, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 27, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 27, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 28, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 28, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 28, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 29, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 29, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 29, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 30, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 30, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 30, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 31, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 31, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 31, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 32, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 32, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 32, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 33, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 33, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 33, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 34, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 34, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 34, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 35, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 35, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 35, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 36, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 36, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 36, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 37, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 37, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 37, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 38, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 38, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 38, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 39, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 39, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 39, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 40, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 40, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 40, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 41, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 41, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 41, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 42, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 42, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 42, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 43, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 43, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 43, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 44, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 44, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 44, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 45, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 45, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 45, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 46, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 46, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 46, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 47, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 47, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 47, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 48, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 48, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 48, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 49, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 49, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 49, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 50, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 50, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 50, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 51, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 51, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 51, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 52, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 52, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 52, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 53, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 53, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 53, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 54, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 54, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 54, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 55, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 55, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 55, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 56, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 56, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 56, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 57, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 57, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 57, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 58, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 58, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 58, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 59, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 59, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 59, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 60, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 60, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 60, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 61, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 61, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 61, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 62, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 62, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 62, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 63, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 63, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now },
                    new AccountEntityModel { Id = num++, AccountStatusId = (int)StatusEnum.Status.Okay, Balance = rand.Next(1, 9999), CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 63, IBAN = "DE42500105173178734641", DateCreated = DateTime.Now }
                );
        }

    }
}
