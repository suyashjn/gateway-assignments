using System.Data.Entity;
using PMT.Data.Models;

namespace PMT.Data
{
    class PMTContext: DbContext
    {
        public PMTContext() : base("wPassengerDB")
        {
        }

        public DbSet<Passenger> Passengers { get; set; }
    }
}
