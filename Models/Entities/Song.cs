using System;

namespace GuitarApp.Models
{
    public class Song
    {
        // model properties
        public int SongID { get; set; }

        public string Name { get; set; }

        public string BaseTuning { get; set; }

        public int CapoPosition { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        // foreign keys
        public int ArtistID { get; set; }
        public int ApplicationUserID { get; set; }

        // navigation properties
        public virtual Artist Artist { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}