using Microsoft.EntityFrameworkCore;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
