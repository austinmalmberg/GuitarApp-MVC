using GuitarApp.DataAccess;
using GuitarApp.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuitarApp.Controllers
{
    public class HomeController : Controller
    {
        private ArtistRepository _artistRepository;
        private SongRepository _songRepository;

        public HomeController()
        {
        }

        public HomeController(ArtistRepository artistRepository, SongRepository songRepository)
        {
            _artistRepository = artistRepository;
            _songRepository = songRepository;
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

        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = new BrowseViewModel
            {
                Artists = ArtistRepository.Get().ToList(),
                Songs = SongRepository.Get().ToList()
            };
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Browse()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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