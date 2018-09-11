using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VinylCollector.Models.Vinyl
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumId { get; set; }

        public string Title { get; set; }

        //[ForeignKey("Artist")]
        public int? ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public int Year { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Track> TrackList { get; set; }

        public Track Track { get; set; }

        public string ImageURL { get; set; }

        public double Price { get; set; }
    }
}