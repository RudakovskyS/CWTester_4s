namespace CWTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingGroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlannedTests", "Groups_Id", "dbo.Groups");
            DropForeignKey("dbo.PlannedTests", "Tests_Id", "dbo.Tests");
            DropForeignKey("dbo.TestResults", "PlannedTests_Id", "dbo.PlannedTests");
            DropForeignKey("dbo.Users", "Groups_Id", "dbo.Groups");
            DropIndex("dbo.PlannedTests", new[] { "Groups_Id" });
            DropIndex("dbo.PlannedTests", new[] { "Tests_Id" });
            DropIndex("dbo.TestResults", new[] { "PlannedTests_Id" });
            DropIndex("dbo.Users", new[] { "Groups_Id" });
            CreateTable(
                "dbo.PassedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        TestDate = c.DateTime(nullable: false),
                        Tests_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Tests_Id)
                .Index(t => t.Tests_Id);
            
            AddColumn("dbo.TestResults", "PassedTestId", c => c.Int(nullable: false));
            AddColumn("dbo.TestResults", "PassedTests_Id", c => c.Int());
            CreateIndex("dbo.TestResults", "PassedTests_Id");
            AddForeignKey("dbo.TestResults", "PassedTests_Id", "dbo.PassedTests", "Id");
            DropColumn("dbo.TestResults", "PlannedTesId");
            DropColumn("dbo.TestResults", "PlannedTests_Id");
            DropColumn("dbo.Users", "GroupId");
            DropColumn("dbo.Users", "Groups_Id");
            DropTable("dbo.Groups");
            DropTable("dbo.PlannedTests");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Groups_Id", c => c.Int());
            AddColumn("dbo.Users", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.TestResults", "PlannedTests_Id", c => c.Int());
            AddColumn("dbo.TestResults", "PlannedTesId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TestResults", "PassedTests_Id", "dbo.PassedTests");
            DropForeignKey("dbo.PassedTests", "Tests_Id", "dbo.Tests");
            DropIndex("dbo.TestResults", new[] { "PassedTests_Id" });
            DropIndex("dbo.PassedTests", new[] { "Tests_Id" });
            DropColumn("dbo.TestResults", "PassedTests_Id");
            DropColumn("dbo.TestResults", "PassedTestId");
            DropTable("dbo.PassedTests");
            CreateIndex("dbo.Users", "Groups_Id");
            CreateIndex("dbo.TestResults", "PlannedTests_Id");
            CreateIndex("dbo.PlannedTests", "Tests_Id");
            CreateIndex("dbo.PlannedTests", "Groups_Id");
            AddForeignKey("dbo.Users", "Groups_Id", "dbo.Groups", "Id");
            AddForeignKey("dbo.TestResults", "PlannedTests_Id", "dbo.PlannedTests", "Id");
            AddForeignKey("dbo.PlannedTests", "Tests_Id", "dbo.Tests", "Id");
            AddForeignKey("dbo.PlannedTests", "Groups_Id", "dbo.Groups", "Id");
        }
    }
}
