using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarApp.Models
{
    public class BrowseViewModel
    {
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Song> Songs { get; set; }
    }

}