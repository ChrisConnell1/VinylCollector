using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VinylCollector.Models.Vinyl;

namespace VinylCollector.ViewModels
{
    public class ArtistFormViewModel
    {
        public Artist Artist { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}