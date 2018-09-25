namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenreIdForArtists : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Artists SET GenreId = 6 WHERE ArtistId = 1");
            Sql("UPDATE Artists SET GenreId = 2 WHERE ArtistId = 2");
            Sql("UPDATE Artists SET GenreId = 6 WHERE ArtistId = 3");
        }
        
        public override void Down()
        {
        }
    }
}
