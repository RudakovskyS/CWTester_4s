namespace CWTester.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserAuthIdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserAuth_Id", "dbo.UserAuths");
            DropIndex("dbo.Users", new[] { "UserAuth_Id" });
            RenameColumn(table: "dbo.Users", name: "UserAuth_Id", newName: "UserAuthId");
            AlterColumn("dbo.Users", "UserAuthId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "UserAuthId");
            AddForeignKey("dbo.Users", "UserAuthId", "dbo.UserAuths", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserAuthId", "dbo.UserAuths");
            DropIndex("dbo.Users", new[] { "UserAuthId" });
            AlterColumn("dbo.Users", "UserAuthId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "UserAuthId", newName: "UserAuth_Id");
            CreateIndex("dbo.Users", "UserAuth_Id");
            AddForeignKey("dbo.Users", "UserAuth_Id", "dbo.UserAuths", "Id");
        }
    }
}
