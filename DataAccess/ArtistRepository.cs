using GuitarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarApp.DataAccess
{
    public class ArtistRepository : GenericRepository<Artist>, IDisposable
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Artist> LookupByName(string name)
        {
            return Get(a => a.Name.Contains(name));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}