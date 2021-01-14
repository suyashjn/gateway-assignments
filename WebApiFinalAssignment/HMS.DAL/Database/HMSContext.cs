using System.Data.Entity;

namespace HMS.DAL.Database
{
    public class HMSContext : DbContext
    {
        // Your context has been configured to use a 'HMSContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HMS.DAL.Database.HMSContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HMSContext' 
        // connection string in the application configuration file.
        public HMSContext()
            : base("name=HMSContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}