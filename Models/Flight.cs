using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Models
{
    public class Flight
    {
        public int FlightID;
        public Destination Source;
        public Destination destination;
        public DateTime departure;
        public DateTime arrival;
        
    }
}