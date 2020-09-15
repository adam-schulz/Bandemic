using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Data
{
    public class TourDate
    {
        [Key]
        public int TourDateId { get; set; }
        [Required]
        public DateTime DateOfShow { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        [Display(Name = "Artist")]
        [Required]
        public virtual Artist Artist { get; set; }
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        [Display(Name = "Venue")]
        [Required]
        public virtual Venue Venue { get; set; }
    }
}
