using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarApp.Models
{
    public class BrowseArtistsViewModel
    {
        public ICollection<Artist> Artists { get; set; }
    }

    public class BrowseSongsViewModel
    {
        public ICollection<Song> Songs { get; set; }
    }

    public class BrowseUsersViewModel
    {
        public ICollection<ApplicationUser> Users { get; set; }
    }
}