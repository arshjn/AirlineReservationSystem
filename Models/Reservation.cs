using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Models
{
    public class Reservation
    {
        public int Pnr; //Passenger Name Record number
        public Flight flight;
        public string Class;
    }
}