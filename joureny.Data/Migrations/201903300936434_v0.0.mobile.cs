namespace joureny.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v00mobile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "MobileNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "MobileNumber");
        }
    }
}
