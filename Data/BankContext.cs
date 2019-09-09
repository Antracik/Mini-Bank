using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
   

    public class BankContext : IdentityDbContext<UserEntityModel, RoleModel, int>
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        //public DbSet<UserDbRepoModel> Users { get; set; }
        public DbSet<RegistrantEntityModel> Registrants { get; set; }
        public DbSet<WalletEntityModel> Wallets { get; set; }
        public DbSet<AccountEntityModel> Accounts { get; set; }
        public DbSet<CurrencyEntityModel> Currency { get; set; }
        public DbSet<CountryEntityModel> Countries { get; set; }
        public DbSet<StatusEntityModel> Status { get; set; }
        public DbSet<TransactionEntityModel> Transaction { get; set; }
        public DbSet<TransactionTypeEntityModel> TransactionType { get; set; }
        public DbSet<FileDescriptorEntityModel> Descriptor { get; set; }
        public DbSet<FileEntityModel> File { get; set; }
        public DbSet<CurrencyExchangeEntityModel> CurrencyExchange { get; set; }
        public DbQuery<AllWalletsWithSums> AllWalletsWithSumsQuery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserDbRepoModel>()
            //    .HasOne(p => p.CreatedByUser)
            //    .WithOne();
            //modelBuilder.Entity<UserDbRepoModel>()
            //    .HasOne(p => p.EditedByUser)
            //    .WithOne();

            //modelBuilder.Entity<RegistrantDbRepoModel>()
            //    .HasOne(p => p.CreatedByUser)
            //    .WithOne();
            //modelBuilder.Entity<RegistrantDbRepoModel>()
            //    .HasOne(p => p.EditedByUser)
            //    .WithOne();

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
                .WithMany( i => i.Accounts)
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
                

            //modelBuilder.Entity<UserDbRepoModel>()
            //    .HasOne(x => x.CreatedByUser)
            //    .WithOne(i => i.Creator)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<UserDbRepoModel>()
            //    .HasOne(x => x.EditedByUser)
            //    .WithOne(i => i.Editor)
            //    .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
