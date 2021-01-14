namespace HMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        BookingStatus = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 300),
                        City = c.String(nullable: false, maxLength: 50),
                        PinCode = c.Int(nullable: false),
                        ContactPerson = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(nullable: false, maxLength: 50),
                        Website = c.String(maxLength: 300),
                        Facebook = c.String(maxLength: 300),
                        Twitter = c.String(maxLength: 300),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomName = c.String(nullable: false, maxLength: 50),
                        RoomCategory = c.Byte(nullable: false),
                        RoomPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 50),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Hotels");
            DropTable("dbo.Bookings");
        }
    }
}
