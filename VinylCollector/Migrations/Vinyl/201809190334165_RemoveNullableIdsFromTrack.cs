namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNullableIdsFromTrack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            AlterColumn("dbo.Tracks", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "AlbumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tracks", "ArtistId");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            AlterColumn("dbo.Tracks", "AlbumId", c => c.Int());
            AlterColumn("dbo.Tracks", "ArtistId", c => c.Int());
            CreateIndex("dbo.Tracks", "ArtistId");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "ArtistId");
        }
    }
}
