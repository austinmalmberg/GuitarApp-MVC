using System;

namespace GuitarApp.Models
{
    public class SetlistEntry
    {
        // model properties
        public int SetlistEntryID { get; set; }
        public int MasteryLevel { get; set; } = 0;
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public DateTime LastPlayed { get; set; } = DateTime.Now;

        // foreign keys
        public string UserID { get; set; }
        public int SongID { get; set; }
        public int SetlistID { get; set; }

        // navigation properties
        public virtual ApplicationUser User { get; set; }
        public virtual Song Song { get; set; }
        public virtual Setlist Setlist { get; set; }
    }
}