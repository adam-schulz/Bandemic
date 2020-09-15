﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models.Venue
{
    public class VenueEdit
    {
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenueLocation { get; set; }
    }
}
