using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarApp.Models
{
    public class SetlistEntry
    {
        [Key]
        public int SetlistEntryID { get; set; }

        [Range(0, 6)]
        public int MasteryLevel { get; set; } = 0;

        public DateTime AddedOn { get; set; } = DateTime.Now;

        public DateTime LastPlayed { get; set; } = DateTime.Now;

        [Required]
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int SongID { get; set; }

        [ForeignKey("SongID")]
        public virtual Song Song { get; set; }
    }
}