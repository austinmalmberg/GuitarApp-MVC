using GuitarApp.DataAccess;
using GuitarApp.Models;
using GuitarApp.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace GuitarApp.Controllers
{
    public class SongController : Controller
    {
        private SongRepository _songRepository;
        private TabRepository _tabRepository;
        private ArtistRepository _artistRepository;

        public SongController()
        {
        }

        public SongController(SongRepository songRepository, ArtistRepository artistRepository, TabRepository tabRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _tabRepository = tabRepository;
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
        public ArtistRepository ArtistRepository
        {
            get
            {
                return _artistRepository ?? new ArtistRepository(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }
            private set
            {
                _artistRepository = value;
            }
        }

        public TabRepository TabRepository
        {
            get
            {
                return _tabRepository ?? new TabRepository(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }
            private set
            {
                _tabRepository = value;
            }
        }

        // GET: /Song/Create
        [Authorize]
        public ActionResult Create(int artistId)
        {
            Artist artist = ArtistRepository.GetById(artistId);
            if (artist == null)
            {
                return new HttpNotFoundResult("Invalid artist ID.");
            }

            var model = new CreateSongViewModel
            {
                ArtistID = artistId,
                ArtistName = artist.Name
            };

            return View(model);
        }

        // POST: /Song/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSongViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Song song = new Song
            {
                Name = model.SongName,
                ArtistID = model.ArtistID,
                Lyrics = model.Lyrics
            };

            SongRepository.Insert(song);
            SongRepository.Save();

            // Redirect to the newly created song
            return RedirectToAction("Details", "Song", new { songId = song.SongID });
        }

        // GET: /Song/Details/5
        public ActionResult Details(int songId, int? tabId)
        {
            var song = SongRepository.GetById(songId);
            if (song == null)
            {
                return new HttpNotFoundResult("Invalid song ID");
            }

            var model = new SongDetailsViewModel
            {
                SongID = song.SongID,
                SongName = song.Name,
                ArtistName = song.Artist.Name,
                Tabs = song.Tabs,
                ActiveTabID = tabId
            };

            return View(model);
        }

        // GET: /Song/Edit/5
        [Authorize]
        public ActionResult Edit(int songId)
        {
            Song song = SongRepository.GetById(songId);
            if (song == null)
            {
                return new HttpNotFoundResult("Invalid song ID");
            }

            var model = new EditSongViewModel
            {
                SongID = song.SongID,
                SongName = song.Name,
                Lyrics = song.Lyrics
            };

            return View(model);
        }

        // POST: /Song/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSongViewModel model)
        {
            if (ModelState.IsValid)
            {
                Song song = SongRepository.GetById(model.SongID);
                if (song != null)
                {
                    song.Name = model.SongName;
                    song.Lyrics = model.Lyrics;
                    SongRepository.Save();

                    // Redirect to the updated song
                    return RedirectToAction("Details", "Song", new { songId = song.SongID });
                }
            }

            return View();
        }

        // DELETE: /Song/Delete/5
        [HttpDelete]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int songId)
        {
            Song song = SongRepository.GetById(songId);
            if (song == null)
            {
                return new HttpNotFoundResult("Invalid song ID");
            }

            SongRepository.Delete(song);
            SongRepository.Save();

            return RedirectToAction("Index", "Home");
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