using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Models
{
    public class Destination
    {
        public string DName { get; set; }
        public string Code { get; set; }
        public int Xcoordinate {get; set;}
        public int Ycoordinate { get; set; }
        public int AirportFee { get; set; } //Additional Fee that an airport may charge 
    }
}