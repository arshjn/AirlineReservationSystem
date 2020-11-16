using AirlineReservationSystem.Gateways;
using AirlineReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AirlineReservationSystem.Controllers
{
    public class FlightController : ApiController
    {
        FlightGateway flightGateway = new FlightGateway();
        [HttpGet]
        public List<Flight> showFlights(string s, string d)
        {
            return flightGateway.GetFlights(s, d);
        }
    }
}