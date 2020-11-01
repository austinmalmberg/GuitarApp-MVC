using GuitarApp.DataAccess;
using GuitarApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuitarApp.Controllers
{
    public class SongController : Controller
    {
        private SongRepository _songRepository;

        public SongController()
        {
        }

        public SongController(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public SongRepository SongRepository
        {
            get
            {
                return _songRepository ?? new SongRepository(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }
            private set
            {
                _songRepository = value;
            }
        }

        // GET: /Song/Create
        public ActionResult Create(int? artistId, string artistName)
        {
            if (artistId != null)
            {
                var model = new CreateSongViewModel { ArtistID = (int) artistId, ArtistName = artistName };
                return View(model);
            }

            return View();
        }

        // POST: /Song/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSongViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Song song = new Song
            {
                Name = model.Name,
                BaseTuning = model.BaseTuning,
                CapoPosition = model.CapoPosition,
                ArtistID = model.ArtistID,
                ContributorID = User.Identity.GetUserId(),
            };

            // Add a new song
            SongRepository.Insert(song);
            SongRepository.Save();

            // Redirect to the newly created song
            return RedirectToAction("Details", "Song", new { id = song.SongID });
        }

        // GET: /Song/Details/5
        public ActionResult Details(int id)
        {
            var song = SongRepository.GetById(id);
            var model = new SongDetailsViewModel
            {
                SongID = song.SongID,
                Name = song.Name,
                BaseTuning = song.BaseTuning,
                CapoPosition = song.CapoPosition,
                LastUpdated = song.LastUpdated,
            };

            // Return the song with the given id
            return View(model);
        }

        // POST: /Song/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditSongViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Song song = new Song
            {
                SongID = model.SongID,
                Name = model.Name,
                BaseTuning = model.BaseTuning,
                CapoPosition = model.CapoPosition,
                ContributorID = User.Identity.GetUserId(),
                LastUpdated = DateTime.Now
            };

            SongRepository.Update(song);
            SongRepository.Save();

            // Redirect to the updated song
            return RedirectToAction("Details", "Song", new { id });
        }

        // DELETE: /Song/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            SongRepository.Delete(id);
            SongRepository.Save();

            return RedirectToAction("Index", "Song");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (SongRepository != null)
                {
                    SongRepository.Dispose();
                    SongRepository = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}