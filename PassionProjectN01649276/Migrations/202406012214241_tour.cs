namespace PassionProjectN01649276.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tour : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Tourid = c.Int(nullable: false, identity: true),
                        Tourname = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Tourid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tours");
        }
    }
}
