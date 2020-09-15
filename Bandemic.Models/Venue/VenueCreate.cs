using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models.Venue
{
    public class VenueCreate
    {
        [Required]
        public string VenueName { get; set; }
        [Required]
        public string VenueAddress { get; set; }
        [Required]
        public string VenueLocation { get; set; }
    }
}
