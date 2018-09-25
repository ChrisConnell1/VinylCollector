namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeGenreIdNullable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "GenreId", c => c.Int());
            CreateIndex("dbo.Artists", "GenreId");
            AddForeignKey("dbo.Artists", "GenreId", "dbo.Genres", "Id");
            DropColumn("dbo.Artists", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Genre", c => c.String());
            DropForeignKey("dbo.Artists", "GenreId", "dbo.Genres");
            DropIndex("dbo.Artists", new[] { "GenreId" });
            DropColumn("dbo.Artists", "GenreId");
        }
    }
}
