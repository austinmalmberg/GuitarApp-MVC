using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarApp.Models
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public virtual ICollection<Song> Songs { get; set; }
    }
}