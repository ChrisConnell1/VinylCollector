using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using VinylCollector.Models.Vinyl;

namespace VinylCollector.Data
{
    public class VinylContext : DbContext
    {
        public VinylContext() : base("VinylContext")
        { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet <Genre> Genres { get; set; }
        public DbSet<TypeOfAlbum> TypesOfAlbum { get; set; }
    }
}