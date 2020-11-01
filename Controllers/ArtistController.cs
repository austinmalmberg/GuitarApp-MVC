using GuitarApp.DataAccess;
using GuitarApp.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GuitarApp.Controllers
{
    public class ArtistController : Controller
    {
        private ArtistRepository _artistRepository;

        public ArtistController()
        {
        }

        public ArtistController(ArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
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

        // GET: /Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Artist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArtistViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Add a new artist
            Artist artist = new Artist { Name = model.Name };

            ArtistRepository.Insert(artist);
            ArtistRepository.Save();

            // Redirect to the newly created artist
            return RedirectToAction("Details", "Artist", new { id = artist.ArtistID });
        }

        // GET: /Artist/Details/5
        public ActionResult Details(int id)
        {
            var artist = ArtistRepository.GetById(id);
            var model = new ArtistDetailsViewModel
            {
                Name = artist.Name,
                Songs = artist.Songs
            };

            // Return the artist with the given id
            return View(model);
        }

        // POST: /Artist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditArtistViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Update the artist with the corresponding id
            Artist artist = new Artist
            {
                ArtistID = model.ArtistID,
                Name = model.Name
            };
            ArtistRepository.Update(artist);
            ArtistRepository.Save();

            // Redirect to the updated artist
            return RedirectToAction("Details", "Artist", new { id = artist.ArtistID });
        }

        // DELETE: /Artist/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            // Delete the artist with the corresponding id
            ArtistRepository.Delete(id);
            ArtistRepository.Save();

            // if (result.Success) { }

            // Redirect to the artist list
            return RedirectToAction("Index", "Artist");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_artistRepository != null)
                {
                    _artistRepository.Dispose();
                    _artistRepository = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}