namespace GuitarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSetlists : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Songs", name: "ApplicationUser_Id", newName: "Contributor_Id");
            RenameIndex(table: "dbo.Songs", name: "IX_ApplicationUser_Id", newName: "IX_Contributor_Id");
            CreateTable(
                "dbo.SetlistEntries",
                c => new
                    {
                        SetlistEntryID = c.Int(nullable: false, identity: true),
                        MasteryLevel = c.Int(nullable: false),
                        AddedOn = c.DateTime(nullable: false),
                        LastPlayed = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        SongID = c.Int(nullable: false),
                        SetlistID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SetlistEntryID)
                .ForeignKey("dbo.Setlists", t => t.SetlistID, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SongID)
                .Index(t => t.SetlistID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Setlists",
                c => new
                    {
                        SetlistID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SetlistID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Songs", "ContributorID", c => c.Int(nullable: false));
            DropColumn("dbo.Songs", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "ApplicationUserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.SetlistEntries", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SetlistEntries", "SongID", "dbo.Songs");
            DropForeignKey("dbo.Setlists", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SetlistEntries", "SetlistID", "dbo.Setlists");
            DropIndex("dbo.Setlists", new[] { "User_Id" });
            DropIndex("dbo.SetlistEntries", new[] { "User_Id" });
            DropIndex("dbo.SetlistEntries", new[] { "SetlistID" });
            DropIndex("dbo.SetlistEntries", new[] { "SongID" });
            DropColumn("dbo.Songs", "ContributorID");
            DropTable("dbo.Setlists");
            DropTable("dbo.SetlistEntries");
            RenameIndex(table: "dbo.Songs", name: "IX_Contributor_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Songs", name: "Contributor_Id", newName: "ApplicationUser_Id");
        }
    }
}
