namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackNavigationPropToAlbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            AddColumn("dbo.Albums", "Track_TrackID", c => c.Int());
            AddColumn("dbo.Tracks", "Album_AlbumId", c => c.Int());
            AddColumn("dbo.Tracks", "Album_AlbumId1", c => c.Int());
            CreateIndex("dbo.Albums", "Track_TrackID");
            CreateIndex("dbo.Tracks", "Album_AlbumId");
            CreateIndex("dbo.Tracks", "Album_AlbumId1");
            AddForeignKey("dbo.Albums", "Track_TrackID", "dbo.Tracks", "TrackID");
            AddForeignKey("dbo.Tracks", "Album_AlbumId1", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Tracks", "Album_AlbumId", "dbo.Albums", "AlbumId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Tracks", "Album_AlbumId1", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Track_TrackID", "dbo.Tracks");
            DropIndex("dbo.Tracks", new[] { "Album_AlbumId1" });
            DropIndex("dbo.Tracks", new[] { "Album_AlbumId" });
            DropIndex("dbo.Albums", new[] { "Track_TrackID" });
            DropColumn("dbo.Tracks", "Album_AlbumId1");
            DropColumn("dbo.Tracks", "Album_AlbumId");
            DropColumn("dbo.Albums", "Track_TrackID");
            CreateIndex("dbo.Tracks", "AlbumId");
            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "AlbumId");
        }
    }
}
