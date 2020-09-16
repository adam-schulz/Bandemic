using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models.TourDate
{
    public class TourDateDetail
    {
        public int TourDateId { get; set; }
        [Display(Name = "Date of Show")]
        public DateTime DateOfShow { get; set; }
        public int ArtistId { get; set; }
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }
        public int VenueId { get; set; }
        [Display(Name = "Venue")]
        public string VenueName { get; set; }
    }
}
