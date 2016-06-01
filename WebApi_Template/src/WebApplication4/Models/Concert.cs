using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Template.Models
{
    public class Concert
    {
        public string ArtistName { get; set; }
        public int ArtistId { get; set; }
        public string TourName { get; set; }
        public DateTime Date { get; set; }
    }
}
