using Microrabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Microrabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}