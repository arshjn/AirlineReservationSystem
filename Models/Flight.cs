using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Models
{
    public class Flight
    {
        public int FlightID;
        public string SourceCode;
        public string DestinationCode;
        public DateTime departure;
        public DateTime arrival;
        
    }
}