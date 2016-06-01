using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Template.Models
{
    public class EventList
    {
        public List<Concert> Events { get; set; }

        // constructor function
        public EventList()
        {
            this.Events = new List<Concert>();
            this.Events.Add(new Concert { ArtistId = 3, TourName = "The Sweet Emotion Tour", Date = new DateTime(2016, 4, 18) }); // Aerosmith
            this.Events.Add(new Concert { ArtistId = 50, TourName = "The Justice for All Tour", Date = new DateTime(2016, 5, 25) }); // Metallica
            this.Events.Add(new Concert { ArtistId = 52, TourName = "The Detroit Rock City Tour", Date = new DateTime(2016, 6, 13) }); // Kiss
            this.Events.Add(new Concert { ArtistId = 133, TourName = "The Couldn't Stand the Weather Tour", Date = new DateTime(2016, 7, 30) }); // SRV
        }
    }
}
