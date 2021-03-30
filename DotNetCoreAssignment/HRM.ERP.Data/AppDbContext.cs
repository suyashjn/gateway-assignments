using HRM.ERP.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRM.ERP.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.IsManager)
                .HasDefaultValue(false);
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
