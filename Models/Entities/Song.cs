using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarApp.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }

        [Required]
        public string Name { get; set; }

        public string BaseTuning { get; set; } = "EADGBe";

        public int CapoPosition { get; set; } = 0;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        [Required]
        public int ArtistID { get; set; }

        [ForeignKey("ArtistID")]
        public virtual Artist Artist { get; set; }

        [Required]
        public string ContributorID { get; set; }

        [ForeignKey("ContributorID")]
        public virtual ApplicationUser Contributor { get; set; }
    }
}