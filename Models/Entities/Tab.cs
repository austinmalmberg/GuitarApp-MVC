using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarApp.Models.Entities
{
    public class Tab
    {
        [Key]
        public int TabID { get; set; }

        [Required]
        public string Content { get; set; }

        public int CapoPosition { get; set; } = 0;

        [Required]
        [ForeignKey("Tuning")]
        public int TuningID { get; set; }

        public virtual Tuning Tuning { get; set; }

        [Required]
        [ForeignKey("Contributor")]
        public string ContributorID { get; set; }

        public virtual ApplicationUser Contributor { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        // Store the Song ID that this tab is associated with
        // The tab revision HEAD is stored in the Song table
        [Required]
        [ForeignKey("Song")]
        public int SongID { get; set; }

        public virtual Song Song { get; set; }

        // Store the id of the parent tab from which the current tab was derived from (for revisioning purposes)
        [ForeignKey("Parent")]
        public int? ParentID { get; set; }

        public virtual Tab Parent { get; set; }
    }
}