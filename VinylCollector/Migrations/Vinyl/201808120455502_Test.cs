namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "Artist_ArtistId", c => c.Int());
            CreateIndex("dbo.Tracks", "Artist_ArtistId");
            AddForeignKey("dbo.Tracks", "Artist_ArtistId", "dbo.Artists", "ArtistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "Artist_ArtistId" });
            DropColumn("dbo.Tracks", "Artist_ArtistId");
        }
    }
}
