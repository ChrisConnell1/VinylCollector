namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTypeOfAlbum : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TypeOfAlbums (Name) VALUES ('LP')");
            Sql("INSERT INTO TypeOfAlbums (Name) VALUES ('Single')");
            Sql("INSERT INTO TypeOfAlbums (Name) VALUES ('Compilation')");
        }
        
        public override void Down()
        {
        }
    }
}
