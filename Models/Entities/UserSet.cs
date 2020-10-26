using System;
using System.Collections.Generic;

namespace GuitarApp.Models
{
    public class Setlist
    {
        // model properties
        public int SetlistID { get; set; }

        public virtual ICollection<SetlistEntry> SetlistEntries { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        // foreign keys
        public int ApplicationUserID { get; set; }

        // navigation properties
        public virtual ApplicationUser User { get; set; }
    }
}