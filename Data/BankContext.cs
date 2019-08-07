using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
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
        public DbSet<CurrencyDbRepoModel> Currency { get; set; }
        public DbSet<CountryDbRepoModel> Countries { get; set; }
        public DbSet<StatusDbRepoModel> Status { get; set; }

    }
}
