namespace GuitarApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArtistCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Created");
        }
    }
}
