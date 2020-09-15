﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Data
{
    public enum Genre { Rock = 1, Pop, Country, Hip_Hop, Blues, Indie, Funk, Jam, Jazz }
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public Genre Genre { get; set; }

        public int TourDateId { get; set; }
        [ForeignKey("TourDateId")]
        [Display(Name = "Upcoming Shows")]
        public virtual TourDate TourDate { get; set; }
    }
}
