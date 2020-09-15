using Bandemic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Models
{
    public class ArtistListItem
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public Genre Genre { get; set; }
    }
}
