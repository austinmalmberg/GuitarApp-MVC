using GuitarApp.Models;
using GuitarApp.Models.Entities;
using System;
using System.Linq;

namespace GuitarApp.DataAccess
{
    public class TuningRepository : GenericRepository<Tuning>, IDisposable
    {
        public TuningRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Tuning GetByValue(string baseTuning)
        {
            return Get(tab => tab.BaseTuning == baseTuning).FirstOrDefault();
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