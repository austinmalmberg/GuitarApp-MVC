using GuitarApp.Models;
using GuitarApp.Models.Entities;
using System;
using System.Collections.Generic;

namespace GuitarApp.DataAccess
{
    public class TabRepository : GenericRepository<Tab>, IDisposable
    {
        public TabRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Tab> GetRevisions(int songId)
        {
            return Get(t => t.SongID == songId);
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