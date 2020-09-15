using Bandemic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
