using GuitarApp.Models;
using GuitarApp.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GuitarApp.Controllers.Api
{
    public class ArtistApiController : ApiController
    {
        readonly ApplicationDbContext _context = new ApplicationDbContext();

        public List<Artist> AllArtists()
        {
            var query = _context.Artists.AsQueryable();
            return query.ToList();
        }

        public Artist GetById(int id)
        {
            var artist = _context.Artists
                .Where(a => a.ArtistID == id)
                .FirstOrDefault();

            return artist;
        }

        public List<Artist> GetByName(string name)
        {
            var query = _context.Artists
                .Where(a => a.Name.Contains(name));

            return query.ToList();
        }
    }
}