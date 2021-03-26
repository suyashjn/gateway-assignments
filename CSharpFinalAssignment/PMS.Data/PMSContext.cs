using PMS.Data.Models;
using System.Data.Entity;

namespace PMS.Data
{
    public class PMSContext: DbContext
    {
        public PMSContext() : base("PMSEntities")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
