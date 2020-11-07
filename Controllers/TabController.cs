using GuitarApp.DataAccess;
using GuitarApp.Models;
using GuitarApp.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuitarApp.Controllers
{
    public class TabController : Controller
    {
        private TabRepository _tabRepository;
        private TuningRepository _tuningRepository;
        private SongRepository _songRepository;

        public TabController()
        {
        }

        public TabController(TabRepository tabRepository, TuningRepository tuningRepository, SongRepository songRepository)
        {
            _tabRepository = tabRepository;
            _tuningRepository = tuningRepository;
            _songRepository = songRepository;
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

        public TuningRepository TuningRepository
        {
            get
            {
                return _tuningRepository ?? new TuningRepository(HttpContext.GetOwinContext().Get<ApplicationDbContext>());
            }

            private set
            {
                _tuningRepository = value;
            }
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

        [Authorize]
        // GET: /Tab/Create
        public ActionResult Create(int songId)
        {
            Song song = SongRepository.GetById(songId);
            if (song == null)
            {
                return new HttpNotFoundResult("Invalid song ID.");
            }

            var model = new CreateTabViewModel
            {
                SongName = song.Name,
                ArtistName = song.Artist.Name,
                SongID = song.SongID
            };

            return View(model);
        }

        // POST: /Tab/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTabViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Model validation

            Song song = SongRepository.GetById(model.SongID);
            if (song == null)
            {
                return new HttpNotFoundResult("Invalid song ID.");
            }

            // Lookup the tuning
            Tuning tuning = TuningRepository.GetByValue(model.BaseTuning);

            // Add tuning if it doesn't already exist
            if (tuning == null)
            {
                TuningRepository.Insert(new Tuning
                {
                    BaseTuning = model.BaseTuning
                });
                TuningRepository.Save();
            }
            else
            {
                Tab existingTab = song.Tabs.FirstOrDefault(
                    tab => tab.TuningID == tuning.TuningID &&
                    tab.CapoPosition == model.CapoPosition);

                if (existingTab != null)
                {
                    // Redirect to the tab with the same tuning, if it exists
                    return RedirectToAction("Details", new { tabId = existingTab.TabID });
                }
            }

            // Add tab

            Tab tab = new Tab
            {
                TuningID = tuning.TuningID,
                CapoPosition = model.CapoPosition,
                Content = model.Content,
                SongID = model.SongID,
                ContributorID = User.Identity.GetUserId(),
            };

            TabRepository.Insert(tab);
            TabRepository.Save();

            return RedirectToAction("Details", "Song", new { songId = song.SongID, tuningId = tab.TuningID });
        }

        [Authorize]
        // GET: /Tab/Revise/5
        public ActionResult Revise(int parentId)
        {
            Tab parent = TabRepository.GetById(parentId);
            if (parent == null)
            {
                return new HttpNotFoundResult("Invalid parent ID.");
            }

            Song song = SongRepository.GetById(parent.SongID);

            var model = new CreateTabViewModel
            {
                SongName = song.Name,
                ArtistName = song.Artist.Name,
                BaseTuning = parent.Tuning.BaseTuning,
                CapoPosition = parent.CapoPosition,
                Content = parent.Content
            };

            return View(model);
        }

        // POST: /Tab/Revise/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Revise(ReviseTabViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Tab parent = TabRepository.GetById(model.ParentID);
            if (parent != null)
            {
                return new HttpNotFoundResult("Invalid parent ID.");
            }

            // Add tab
            Tab tab = new Tab
            {
                ParentID = model.ParentID,
                TuningID = parent.TuningID,
                Content = model.Content,
                SongID = parent.SongID,
                ContributorID = User.Identity.GetUserId()
            };

            TabRepository.Insert(tab);
            TabRepository.Save();

            return RedirectToAction("Details", "Song", new { songId = tab.SongID, tabId = tab.TabID });
        }

        // GET: /Tab/Details/5
        public ActionResult Details(int tabId)
        {
            Tab tab = TabRepository.GetById(tabId);

            if (tab == null)
            {
                return new HttpNotFoundResult("No tab found with that ID.");
            }

            Tuning tuning = TuningRepository.GetById(tab.TuningID);

            var model = new TabDetailsViewModel
            {
                BaseTuning = tuning.BaseTuning,
                CapoPosition = tab.CapoPosition,
                Content = tab.Content,
                ContributorName = tab.Contributor.UserName,
                Created = tab.Created
            };

            return View(model);
        }

        [Authorize]
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int tabId)
        {
            Tab tab = TabRepository.GetById(tabId);
            if (tab == null)
            {
                return new HttpNotFoundResult("Invalid tab ID.");
            }

            TabRepository.Delete(tab);
            TabRepository.Save();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_tabRepository != null)
                {
                    _tabRepository.Dispose();
                    _tabRepository = null;
                }

                if (_tuningRepository != null)
                {
                    _tuningRepository.Dispose();
                    _tuningRepository = null;
                }

                if (_songRepository != null)
                {
                    _songRepository.Dispose();
                    _songRepository = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}