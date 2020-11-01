namespace GuitarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Songs", new[] { "Contributor_Id" });
            DropIndex("dbo.SetlistEntries", new[] { "User_Id" });
            DropIndex("dbo.Setlists", new[] { "User_Id" });
            DropColumn("dbo.Songs", "ContributorID");
            DropColumn("dbo.SetlistEntries", "UserID");
            DropColumn("dbo.Setlists", "UserID");
            RenameColumn(table: "dbo.Songs", name: "Contributor_Id", newName: "ContributorID");
            RenameColumn(table: "dbo.SetlistEntries", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.Setlists", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.Songs", "ContributorID", c => c.String(maxLength: 128));
            AlterColumn("dbo.SetlistEntries", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Setlists", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Songs", "ContributorID");
            CreateIndex("dbo.SetlistEntries", "UserID");
            CreateIndex("dbo.Setlists", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Setlists", new[] { "UserID" });
            DropIndex("dbo.SetlistEntries", new[] { "UserID" });
            DropIndex("dbo.Songs", new[] { "ContributorID" });
            AlterColumn("dbo.Setlists", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.SetlistEntries", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Songs", "ContributorID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Setlists", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.SetlistEntries", name: "UserID", newName: "User_Id");
            RenameColumn(table: "dbo.Songs", name: "ContributorID", newName: "Contributor_Id");
            AddColumn("dbo.Setlists", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.SetlistEntries", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Songs", "ContributorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Setlists", "User_Id");
            CreateIndex("dbo.SetlistEntries", "User_Id");
            CreateIndex("dbo.Songs", "Contributor_Id");
        }
    }
}
