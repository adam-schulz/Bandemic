using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models.Venue
{
    public class VenueListItem
    {
        public int VenueId { get; set; }
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }
        [Display(Name = "Address")]
        public string VenueAddress { get; set; }
        [Display(Name = "Location")]
        public string VenueLocation { get; set; }
    }
}
