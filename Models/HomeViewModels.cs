using GuitarApp.Models.Entities;
using System.Collections.Generic;

namespace GuitarApp.Models
{
    public class BrowseViewModel
    {
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Song> Songs { get; set; }
    }

}