using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Data
{
    public class TourDate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateOfShow { get; set; }
    }
}
