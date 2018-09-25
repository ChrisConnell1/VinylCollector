using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VinylCollector.Models.Vinyl;

namespace VinylCollector.ViewModels
{
    public class AlbumFormViewModel
    {
        public IEnumerable<Artist> Artist { get; set; }
        public Album Album { get; set; }
        public IEnumerable<TypeOfAlbum> TypeOfAlbum { get; set; }
        //public List<Track> Tracks { get; set; }   Do we need this just to create an album? TrackList is already part of Album class.
    }
}