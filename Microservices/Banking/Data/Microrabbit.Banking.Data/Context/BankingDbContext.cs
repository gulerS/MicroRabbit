using Microsoft.EntityFrameworkCore;
using Microrabbit.Banking.Domain.Models;

namespace Microrabbit.Banking.Data.Context {
    public class BankingDbContext : DbContext {
        public BankingDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
