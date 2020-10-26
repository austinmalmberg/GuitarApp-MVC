using System;

namespace GuitarApp.Models
{
    public class SetlistEntry
    {
        // model properties
        public int SetlistEntryID { get; set; }

        public int MasteryLevel { get; set; }

        public DateTime AddedOn { get; set; }

        public DateTime LastPlayed { get; set; }

        // foreign keys
        public int ApplicationUserID { get; set; }
        public int SongID { get; set; }

        // navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual Song Song { get; set; }
    }
}