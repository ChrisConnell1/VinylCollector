namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbGeneratedNoneKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Tracks", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Tracks", new[] { "Album_AlbumId" });
            DropIndex("dbo.Tracks", new[] { "Artist_ArtistId" });
            RenameColumn(table: "dbo.Albums", name: "Artist_ArtistId", newName: "ArtistId");
            RenameColumn(table: "dbo.Tracks", name: "Album_AlbumId", newName: "AlbumId");
            RenameColumn(table: "dbo.Tracks", name: "Artist_ArtistId", newName: "ArtistId");
            DropPrimaryKey("dbo.Albums");
            DropPrimaryKey("dbo.Artists");
            DropPrimaryKey("dbo.Tracks");
            AlterColumn("dbo.Albums", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "TrackID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tracks", "ArtistId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Albums", "AlbumId");
            AddPrimaryKey("dbo.Artists", "ArtistId");
            AddPrimaryKey("dbo.Tracks", "TrackID");
            CreateIndex("dbo.Albums", "ArtistId");
            CreateIndex("dbo.Tracks", "ArtistId");
            CreateIndex("dbo.Tracks", "AlbumId");
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "ArtistId");
            AddForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "ArtistId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            DropPrimaryKey("dbo.Tracks");
            DropPrimaryKey("dbo.Artists");
            DropPrimaryKey("dbo.Albums");
            AlterColumn("dbo.Tracks", "ArtistId", c => c.Int());
            AlterColumn("dbo.Tracks", "AlbumId", c => c.Int());
            AlterColumn("dbo.Tracks", "TrackID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Artists", "ArtistId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int());
            AlterColumn("dbo.Albums", "AlbumId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tracks", "TrackID");
            AddPrimaryKey("dbo.Artists", "ArtistId");
            AddPrimaryKey("dbo.Albums", "AlbumId");
            RenameColumn(table: "dbo.Tracks", name: "ArtistId", newName: "Artist_ArtistId");
            RenameColumn(table: "dbo.Tracks", name: "AlbumId", newName: "Album_AlbumId");
            RenameColumn(table: "dbo.Albums", name: "ArtistId", newName: "Artist_ArtistId");
            CreateIndex("dbo.Tracks", "Artist_ArtistId");
            CreateIndex("dbo.Tracks", "Album_AlbumId");
            CreateIndex("dbo.Albums", "Artist_ArtistId");
            AddForeignKey("dbo.Tracks", "Artist_ArtistId", "dbo.Artists", "ArtistId");
            AddForeignKey("dbo.Tracks", "Album_AlbumId", "dbo.Albums", "AlbumId");
            AddForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists", "ArtistId");
        }
    }
}
