using Bandemic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models
{
    public class ArtistDetail
    {
        public int ArtistId { get; set; }
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        public Genre Genre { get; set; }
    }
}
