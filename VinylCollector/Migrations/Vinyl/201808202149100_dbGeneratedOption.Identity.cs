namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbGeneratedOptionIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropPrimaryKey("dbo.Albums");
            DropPrimaryKey("dbo.Artists");
            DropPrimaryKey("dbo.Tracks");
            AlterColumn("dbo.Albums", "AlbumId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Artists", "ArtistId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Tracks", "TrackID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Albums", "AlbumId");
            AddPrimaryKey("dbo.Artists", "ArtistId");
            AddPrimaryKey("dbo.Tracks", "TrackID");
            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "ArtistId");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "ArtistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropPrimaryKey("dbo.Tracks");
            DropPrimaryKey("dbo.Artists");
            DropPrimaryKey("dbo.Albums");
            AlterColumn("dbo.Tracks", "TrackID", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Albums", "AlbumId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tracks", "TrackID");
            AddPrimaryKey("dbo.Artists", "ArtistId");
            AddPrimaryKey("dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "ArtistId");
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "ArtistId");
            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "AlbumId");
        }
    }
}
