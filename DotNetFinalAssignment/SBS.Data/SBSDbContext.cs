using System.Data.Entity;
using SBS.Data.Models;

namespace SBS.Data
{
    public class SBSDbContext : DbContext
    {
        public SBSDbContext() : base("name=SBSDB")
        { }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<AppointBooking> AppointBookings { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}

