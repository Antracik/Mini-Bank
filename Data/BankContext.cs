using Data.Entities;
using Data.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
   

    public class BankContext : IdentityDbContext<UserDbRepoModel, RoleModel, int>
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        //public DbSet<UserDbRepoModel> Users { get; set; }
        public DbSet<RegistrantDbRepoModel> Registrants { get; set; }
        public DbSet<WalletDbRepoModel> Wallets { get; set; }
        public DbSet<AccountDbRepoModel> Accounts { get; set; }
        public DbSet<CurrencyDbRepoModel> Currency { get; set; }
        public DbSet<CountryDbRepoModel> Countries { get; set; }
        public DbSet<StatusDbRepoModel> Status { get; set; }
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

            modelBuilder.Entity<RegistrantDbRepoModel>()
                .HasOne(x => x.User)
                .WithOne(x => x.Registrant)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDbRepoModel>()
                .HasOne(x => x.Registrant)
                .WithOne(i => i.User)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WalletDbRepoModel>()
                .HasOne(x => x.Registrant)
                .WithMany(x => x.Wallets)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccountDbRepoModel>()
                .HasOne(x => x.Wallet)
                .WithMany( i => i.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDbRepoModel>()
                .HasOne(x => x.CreatedByUser)
                .WithMany()
                .HasForeignKey(m => m.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDbRepoModel>()
                .HasOne(x => x.EditedByUser)
                .WithMany()
                .HasForeignKey(m => m.EditedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistrantDbRepoModel>()
               .HasOne(x => x.CreatedByUser)
               .WithMany()
               .HasForeignKey(m => m.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegistrantDbRepoModel>()
               .HasOne(x => x.EditedByUser)
               .WithMany()
               .HasForeignKey(m => m.EditedById)
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
