using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VinylCollector.Models.Vinyl
{
    public class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackID { get; set; }
        public string Title { get; set; }

        //I believe what I need here, is ArtistId, and AlbumId, which are foreign keys to those tables. This would link a track to both an artist and an album by ID.
        //[ForeignKey ("Artist")]
        public virtual Artist Artist { get; set; }
        public int? ArtistId { get; set; }

        //[ForeignKey("Album")]
        public virtual Album Album  { get; set; }
        public int? AlbumId { get; set; }
        public bool IsSingle { get; set; }
        public string Length { get; set; }
    }
}