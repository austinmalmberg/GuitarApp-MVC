using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuitarApp.Models
{
    public class CreateSongViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Song Name")]
        public string Name { get; set; }

        [Required]
        public int ArtistID { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [StringLength(12)]
        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Required]
        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }
    }
    public class SongDetailsViewModel
    {
        public int SongID { get; set; }

        [Display(Name = "Song Name")]
        public string Name { get; set; }

        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }

        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public string Contributor { get; set; }
    }

    public class EditSongViewModel
    {
        public int SongID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Song Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Required]
        [Range(0, 24, ErrorMessage = "Range must be between {0} and {1}.")]
        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }
    }
}