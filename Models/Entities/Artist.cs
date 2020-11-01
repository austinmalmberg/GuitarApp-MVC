using System;
using System.Collections.Generic;

namespace GuitarApp.Models
{
    public class Artist
    {
        // model properties
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        // navigation properties
        public virtual ICollection<Song> Songs { get; set; }
    }
}