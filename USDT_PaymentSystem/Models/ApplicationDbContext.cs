using Microsoft.EntityFrameworkCore;
using USDT_PaymentSystem.Models;

namespace USDT_PaymentSystem
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=USDT_PaymentSystemDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}