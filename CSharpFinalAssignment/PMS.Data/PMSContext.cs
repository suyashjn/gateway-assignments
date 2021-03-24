using System.Data.Entity;
using PMS.Data.Models;

namespace PMS.Data
{
    public class PMSContext: DbContext
    {
        public PMSContext() : base("HMSEntities")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
