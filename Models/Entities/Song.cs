using System;

namespace GuitarApp.Models
{
    public class Song
    {
        // model properties
        public int SongID { get; set; }
        public string Name { get; set; }
        public string BaseTuning { get; set; }
        public int CapoPosition { get; set; } = 0;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;

        // foreign keys
        public int ArtistID { get; set; }
        public string ContributorID { get; set; }

        // navigation properties
        public virtual Artist Artist { get; set; }
        public virtual ApplicationUser Contributor { get; set; }
    }
}