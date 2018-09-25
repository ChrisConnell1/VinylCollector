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
    public class ArtistsController : Controller
    {
        private VinylContext db = new VinylContext();

        // GET: Artists
        public ActionResult Index()
        {
            var artists = db.Artists.Include(c => c.Genre).ToList();
            return View(artists);
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = db.Artists.Include(a => a.Genre).SingleOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistId,Name,Genre")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        public ActionResult New()
        {
            var genres = db.Genres.ToList();
            var viewModel = new ArtistFormViewModel
            {
                Genres = genres
            };

            return View("ArtistForm", viewModel);
        }

        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            var artist = db.Artists.Include(a => a.Genre).SingleOrDefault(a => a.ArtistId == id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ArtistFormViewModel
            {
                Artist = artist,
                Genres = db.Genres.ToList()
            };
            
            return View("ArtistForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Artist artist)
        {

            if (artist.ArtistId == 0)
            {
                db.Artists.Add(artist);
            }

            else
            {
                var artistInDb = db.Artists.Single(c => c.ArtistId == artist.ArtistId);

                artistInDb.Name = artist.Name;
                artistInDb.GenreId = artist.GenreId;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Artists");

        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtistId,Name,Genre")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = db.Artists.Include(a => a.Genre).SingleOrDefault(i => i.ArtistId == id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
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
