using System;
using System.Collections.Generic;

namespace GuitarApp.Models
{
    public class Setlist
    {
        // model properties
        public int SetlistID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // foreign keys
        public string UserID { get; set; }

        // navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SetlistEntry> SetlistEntries { get; set; }

    }
}