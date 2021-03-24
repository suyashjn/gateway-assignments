using System.Data.Entity;

namespace HMS.DAL.Database
{
    public class HMSContext : DbContext
    {
        public HMSContext() : base("name=HMSContext")
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}