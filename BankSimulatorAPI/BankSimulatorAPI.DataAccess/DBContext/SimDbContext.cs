using BankSimulatorAPI.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankSimulatorAPI.DataAccess.DBContext
{
    public class SimDbContext : DbContext
    {
        public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
        {

        }

        //dbsets
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //override the method in DbContext //We will use it when creating entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
