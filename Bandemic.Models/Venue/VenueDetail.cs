using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models.Venue
{
    public class VenueDetail
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenueLocation { get; set; }
    }
}
