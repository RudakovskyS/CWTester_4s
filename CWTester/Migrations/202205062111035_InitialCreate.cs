namespace CWTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuesionId = c.Int(nullable: false),
                        Text = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        Questions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Questions_Id)
                .Index(t => t.Questions_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        Text = c.String(),
                        MediaId = c.Int(nullable: false),
                        Tests_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.MediaId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Tests_Id)
                .Index(t => t.MediaId)
                .Index(t => t.Tests_Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlannedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        Groups_Id = c.Int(),
                        Tests_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Groups_Id)
                .ForeignKey("dbo.Tests", t => t.Tests_Id)
                .Index(t => t.Groups_Id)
                .Index(t => t.Tests_Id);
            
            CreateTable(
                "dbo.QuestionResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        QuestionId = c.Int(nullable: false),
                        BottomMark = c.Int(nullable: false),
                        TopMark = c.Int(nullable: false),
                        Questions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Questions_Id)
                .Index(t => t.Questions_Id);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PlannedTesId = c.Int(nullable: false),
                        Result = c.Int(nullable: false),
                        PlannedTests_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlannedTests", t => t.PlannedTests_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PlannedTests_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        GroupId = c.Int(nullable: false),
                        Groups_Id = c.Int(),
                        UserAuth_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Groups_Id)
                .ForeignKey("dbo.UserAuths", t => t.UserAuth_Id)
                .Index(t => t.Groups_Id)
                .Index(t => t.UserAuth_Id);
            
            CreateTable(
                "dbo.UserAuths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserAuth_Id", "dbo.UserAuths");
            DropForeignKey("dbo.Users", "Groups_Id", "dbo.Groups");
            DropForeignKey("dbo.TestResults", "PlannedTests_Id", "dbo.PlannedTests");
            DropForeignKey("dbo.QuestionResults", "Questions_Id", "dbo.Questions");
            DropForeignKey("dbo.PlannedTests", "Tests_Id", "dbo.Tests");
            DropForeignKey("dbo.PlannedTests", "Groups_Id", "dbo.Groups");
            DropForeignKey("dbo.Answers", "Questions_Id", "dbo.Questions");
            DropForeignKey("dbo.Questions", "Tests_Id", "dbo.Tests");
            DropForeignKey("dbo.Questions", "MediaId", "dbo.Media");
            DropIndex("dbo.Users", new[] { "UserAuth_Id" });
            DropIndex("dbo.Users", new[] { "Groups_Id" });
            DropIndex("dbo.TestResults", new[] { "PlannedTests_Id" });
            DropIndex("dbo.TestResults", new[] { "UserId" });
            DropIndex("dbo.QuestionResults", new[] { "Questions_Id" });
            DropIndex("dbo.PlannedTests", new[] { "Tests_Id" });
            DropIndex("dbo.PlannedTests", new[] { "Groups_Id" });
            DropIndex("dbo.Questions", new[] { "Tests_Id" });
            DropIndex("dbo.Questions", new[] { "MediaId" });
            DropIndex("dbo.Answers", new[] { "Questions_Id" });
            DropTable("dbo.UserAuths");
            DropTable("dbo.Users");
            DropTable("dbo.TestResults");
            DropTable("dbo.QuestionResults");
            DropTable("dbo.PlannedTests");
            DropTable("dbo.Groups");
            DropTable("dbo.Tests");
            DropTable("dbo.Media");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
