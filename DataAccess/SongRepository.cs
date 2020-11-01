using GuitarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarApp.DataAccess
{
    public class SongRepository : GenericRepository<Song>, IDisposable
    {

        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Song> LookupByName(string name)
        {
            return Get(s => s.Name.Contains(name));
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}