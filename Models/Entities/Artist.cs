﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarApp.Models.Entities
{
    public class Artist
    {
        [Key]
        public int ArtistID { get; set; }

        [Required]
        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public string WikipediaUrl { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public virtual ICollection<Song> Songs { get; set; }
    }
}