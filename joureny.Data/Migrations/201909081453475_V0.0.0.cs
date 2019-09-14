namespace joureny.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V000 : DbMigration
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        MobileNumber = c.Int(nullable: false),
                        PasswordSalt = c.String(),
                        Role = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAnswerQuestions",
                c => new
                    {
                        QuestionId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.UserId })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Metadata = c.String(),
                        QuestionType = c.Int(nullable: false),
                        QuestionTab = c.Int(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsMandatory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TripQuestions",
                c => new
                    {
                        QuestionId = c.Long(nullable: false),
                        TripId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.TripId })
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.TripId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserTrips", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswerQuestions", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAnswerQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TripQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.UserTrips", "TripId", "dbo.Trips");
            DropForeignKey("dbo.TripQuestions", "TripId", "dbo.Trips");
            DropIndex("dbo.UserTrips", new[] { "TripId" });
            DropIndex("dbo.UserTrips", new[] { "UserId" });
            DropIndex("dbo.TripQuestions", new[] { "TripId" });
            DropIndex("dbo.TripQuestions", new[] { "QuestionId" });
            DropIndex("dbo.UserAnswerQuestions", new[] { "UserId" });
            DropIndex("dbo.UserAnswerQuestions", new[] { "QuestionId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropTable("dbo.UserTrips");
            DropTable("dbo.Trips");
            DropTable("dbo.TripQuestions");
            DropTable("dbo.Questions");
            DropTable("dbo.UserAnswerQuestions");
            DropTable("dbo.Users");
            DropTable("dbo.Feedbacks");
        }
    }
}
