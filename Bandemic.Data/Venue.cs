using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Data
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string VenueLocation { get; set; }
        public int TourDateId { get; set; }
        [ForeignKey("TourDateId")]
        [Display(Name = "Upcoming Shows")]
        public virtual TourDate TourDate { get; set; }
    }
}
