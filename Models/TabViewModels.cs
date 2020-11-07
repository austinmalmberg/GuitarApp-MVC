using System;
using System.ComponentModel.DataAnnotations;

namespace GuitarApp.Models
{
    public class TabDetailsViewModel
    {
        public int TabID { get; set; }

        [Required]
        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Required]
        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        [Display(Name = "Contributor Name")]
        public string ContributorName { get; set; }
    }

    public class CreateTabViewModel
    {
        [Required]
        public int SongID { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Required]
        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }

        [Required]
        public string Content { get; set; }
    }

    public class ReviseTabViewModel
    {
        [Required]
        public int ParentID { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Display(Name = "Base Tuning")]
        public string BaseTuning { get; set; }

        [Display(Name = "Capo Position")]
        public int CapoPosition { get; set; }

        [Required]
        public string Content { get; set; }
    }
}