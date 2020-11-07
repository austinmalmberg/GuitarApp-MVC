using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarApp.Models.Entities
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public string Name { get; set; }

        public string Lyrics { get; set; }

        // Song will only keep the TabID of the latest tab

        [Required]
        [ForeignKey("Artist")]
        public int ArtistID { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual ICollection<Tab> Tabs { get; set; }
    }
}