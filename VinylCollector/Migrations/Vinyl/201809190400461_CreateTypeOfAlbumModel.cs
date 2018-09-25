namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTypeOfAlbumModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeOfAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Albums", "TypeOfAlbumId", c => c.Int(nullable: true));
            CreateIndex("dbo.Albums", "TypeOfAlbumId");
            AddForeignKey("dbo.Albums", "TypeOfAlbumId", "dbo.TypeOfAlbums", "Id", cascadeDelete: true);
            DropColumn("dbo.Albums", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "Type", c => c.String());
            DropForeignKey("dbo.Albums", "TypeOfAlbumId", "dbo.TypeOfAlbums");
            DropIndex("dbo.Albums", new[] { "TypeOfAlbumId" });
            DropColumn("dbo.Albums", "TypeOfAlbumId");
            DropTable("dbo.TypeOfAlbums");
        }
    }
}
