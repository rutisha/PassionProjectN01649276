namespace PassionProjectN01649276.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Bookingdate = c.String(),
                        Status = c.String(),
                        CustomerId = c.Int(nullable: false),
                        TourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Tours", t => t.TourId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.TourId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "TourId", "dbo.Tours");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "TourId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.Bookings");
        }
    }
}
