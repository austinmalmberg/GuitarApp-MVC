using GuitarApp.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarApp.Models
{
    public class BrowseArtistsViewModel
    {
        public ICollection<Artist> Artists { get; set; }
    }

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