namespace joureny.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v000 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TripName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTrips",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        TripId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.TripId })
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTrips", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserTrips", "TripId", "dbo.Trips");
            DropIndex("dbo.UserTrips", new[] { "TripId" });
            DropIndex("dbo.UserTrips", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserTrips");
            DropTable("dbo.Trips");
        }
    }
}
