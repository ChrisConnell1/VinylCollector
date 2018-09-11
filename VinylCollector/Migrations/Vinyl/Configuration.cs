namespace VinylCollector.Migrations.Vinyl
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VinylCollector.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<VinylCollector.Data.VinylContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\Vinyl";
        }

        protected override void Seed(VinylCollector.Data.VinylContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Artists.AddOrUpdate(
            //    a => a.Name, DummyData.getArtists().ToArray());

            //context.Albums.AddOrUpdate(
            //    b => b.Title, DummyData.getAlbums(context).ToArray());

            //context.Tracks.AddOrUpdate(
            //    c => c.Title, DummyData.getTracks(context).ToArray());

            context.SaveChanges();
        }
    }
}
