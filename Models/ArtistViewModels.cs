using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuitarApp.Models
{
    public class CreateArtistViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Artist Name")]
        public string Name { get; set; }
    }
    public class ArtistDetailsViewModel
    {
        public int ArtistID { get; set; }

        [Display(Name = "Artist Name")]
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; }
    }

    public class EditArtistViewModel
    {
        public int ArtistID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Artist Name")]
        public string Name { get; set; }
    }
}