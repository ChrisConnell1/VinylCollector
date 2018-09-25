using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VinylCollector.Data;
using VinylCollector.Models.Vinyl;
using VinylCollector.ViewModels;

namespace VinylCollector.Controllers
{
    public class AlbumsController : Controller
    {
        private VinylContext db = new VinylContext();

        // GET: Albums
        public ActionResult Index()
        {
            var albums = db.Albums.Include(c => c.Track).ToList();

            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {

            Album album = db.Albums.Include(a => a.Type).Include(a => a.Track).Single(a => a.AlbumId == id);

            if (album == null)
            {
                return HttpNotFound();
            }


            return View(album);
        }

        // GET: Albums/Create

        public ActionResult New()
        {
            var types = db.TypesOfAlbum.ToList();
            var artists = db.Artists.ToList();

            var viewModel = new AlbumFormViewModel
            {
                Artist = artists,
                TypeOfAlbum = types
            };

            return View("AlbumForm", viewModel);
        }




        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,Title,Year,Type,ImageURL,Price")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            var album = db.Albums.Include(a => a.Type).SingleOrDefault(a => a.AlbumId == id);
            var artists = db.Artists.ToList();

            if (album == null)
            {
                return HttpNotFound();
            }

            var viewModel = new AlbumFormViewModel
            {
                Artist = artists,
                Album = album,
                TypeOfAlbum = db.TypesOfAlbum.ToList()
            };
            return View("AlbumForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Album album)
        {
            if (album.AlbumId == 0)
            {
                db.Albums.Add(album);
            }

            else
            {
                var albumInDb = db.Albums.Single(a => a.AlbumId == album.AlbumId);

                albumInDb.Title = album.Title;
                albumInDb.TypeOfAlbumId = album.TypeOfAlbumId;
                albumInDb.Price = album.Price;
                albumInDb.TrackList = album.TrackList;
                albumInDb.ImageURL = album.ImageURL;
                albumInDb.Year = album.Year;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Albums");
        }


        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,Title,Year,Type,ImageURL,Price")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
