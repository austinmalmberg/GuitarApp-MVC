﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarApp.Models.Entities
{
    public class Setlist
    {
        [Key]
        public int SetlistID { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<SetlistEntry> SetlistEntries { get; set; }

    }
}