using GuitarApp.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarApp.Models
{
    public class CreateSongViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Required]
        public int ArtistID { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        public string Lyrics { get; set; }
    }

    public class SongDetailsViewModel
    {
        public int SongID { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        public string ArtistName { get; set; }

        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }

        public ICollection<Tab> Tabs { get; set; }

        public int? ActiveTabID { get; set; }
    }

    public class EditSongViewModel
    {
        [Required]
        public int SongID { get; set; }

        [StringLength(100)]
        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        public string Lyrics { get; set; }
    }
}