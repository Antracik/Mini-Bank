using Microsoft.EntityFrameworkCore;
using Mini_Bank.DbRepo.Models;

namespace Mini_Bank.DbContexts
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options)
            : base(options)
        { }

        public DbSet<UserDbRepoModel> Users { get; set; }
        public DbSet<RegistrantDbRepoModel> Registrants { get; set; }
        public DbSet<WalletDbRepoModel> Wallets { get; set; }
        public DbSet<AccountDbRepoModel> Accounts { get; set; }

    }
}
