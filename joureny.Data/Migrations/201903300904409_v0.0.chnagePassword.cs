namespace joureny.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v00chnagePassword : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Message = c.String(),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Users", "PasswordSalt", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropColumn("dbo.Users", "PasswordSalt");
            DropTable("dbo.Feedbacks");
        }
    }
}
