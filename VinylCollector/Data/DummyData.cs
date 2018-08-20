using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VinylCollector.Models.Vinyl;

namespace VinylCollector.Data
{
    public class DummyData
    {
        public static List<Artist> getArtists()
        {
            List<Artist> artists = new List<Artist>()
            {
                new Artist()
                {
                    Name="Fleetwood Mac",
                    Genre="Classic Rock"
                },

                new Artist()
                {
                    Name="Alt-J",
                    Genre="Indie Rock"
                }

            };


            return artists;
        }

        public static List<Album> getAlbums(VinylContext context)
        {
            var albums = new List<Album>()
            {
                new Album()
                {
                    Title="Rumors",
                    Type="LP",
                    Year=1971,
                    ImageURL="https://upload.wikimedia.org/wikipedia/en/f/fb/FMacRumours.PNG",
                    Artist= context.Artists.SingleOrDefault(i => i.Name == "Fleetwood Mac")
                },

                new Album()
                {
                    Title="An Awesome Wave",
                    Type="LP",
                    Year=2012,
                    ImageURL="https://upload.wikimedia.org/wikipedia/en/d/d0/Alt-J_-_An_Awesome_Wave.png",
                    Artist= context.Artists.SingleOrDefault(i => i.Name == "Alt-J")
                }
            };

            //Sort the albums by Title before returning the model... De
            albums.Sort((a, b) => a.Title.CompareTo(b.Title));

            return albums;
        }

        public static List<Track> getTracks(VinylContext context)
        {

            var tracks = new List<Track>()
            {
                new Track()
                {
                Title = "Dreams",
                IsSingle = true,
                Length = "3:57",
                Album = context.Albums.SingleOrDefault(i => i.Title == "Rumors")
                },

                new Track()
                {
                    Title="Go Your Own Way",
                    IsSingle = true,
                    Length = "5:14",
                    Album = context.Albums.SingleOrDefault(i => i.Title == "Rumors")
                },

                new Track()
                {
                    Title="Breezeblocks",
                    IsSingle=true,
                    Length="4:13",
                    Album = context.Albums.SingleOrDefault(i => i.Title == "An Awesome Wave")
                }

            };


            return tracks;
        }


            
    }
}