using System.Data.Entity.Migrations;

namespace SBS.Data.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointBookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                        MechanicId = c.Int(),
                        ServiceId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        UpdatedBy = c.Int(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.Mechanics", t => t.MechanicId)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.DealerId)
                .Index(t => t.MechanicId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Email = c.String(),
                        Mobile = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mechanics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Mobile = c.String(),
                        Make = c.String(),
                        Email = c.String(),
                        DealerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .Index(t => t.DealerId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicensePlate = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        ChassisNo = c.String(),
                        OwnerId = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(nullable: false),
                        Email = c.String(),
                        Mobile = c.String(),
                        Password = c.String(),
                        Question = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.AppointBookings", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.AppointBookings", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Mechanics", "DealerId", "dbo.Dealers");
            DropForeignKey("dbo.AppointBookings", "MechanicId", "dbo.Mechanics");
            DropForeignKey("dbo.AppointBookings", "DealerId", "dbo.Dealers");
            DropIndex("dbo.Vehicles", new[] { "Customer_Id" });
            DropIndex("dbo.Mechanics", new[] { "DealerId" });
            DropIndex("dbo.AppointBookings", new[] { "ServiceId" });
            DropIndex("dbo.AppointBookings", new[] { "MechanicId" });
            DropIndex("dbo.AppointBookings", new[] { "DealerId" });
            DropIndex("dbo.AppointBookings", new[] { "VehicleId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Services");
            DropTable("dbo.Mechanics");
            DropTable("dbo.Dealers");
            DropTable("dbo.AppointBookings");
        }
    }
}
