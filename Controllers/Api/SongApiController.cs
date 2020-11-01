using GuitarApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GuitarApp.Controllers
{
    public class SongApiController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Song
        public List<Song> AllSongs()
        {
            var query = _context.Songs.AsQueryable();

            return query.ToList();
        }

        public List<Song> GetSongsByArtist(Artist artist)
        {
            var query = _context.Songs
                .Where(s => s.Artist == artist);

            return query.ToList();
        }

        public List<Song> GetSongsByName(string name)
        {
            var query = _context.Songs
                .Where(s => s.Name.Contains(name));

            return query.ToList();
        }
    }
}