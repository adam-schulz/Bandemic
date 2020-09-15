using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models.TourDate
{
    public class TourDateCreate
    {
        [Required]
        public DateTime DateOfShow { get; set; }
        public int ArtistId { get; set; }
        public int VenueId { get; set; }
    }
}
