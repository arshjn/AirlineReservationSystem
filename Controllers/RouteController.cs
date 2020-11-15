using AirlineReservationSystem.Gateways;
using AirlineReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AirlineReservationSystem.Controllers
{

    //[Route("api/[controller]")]
    public class RouteController : ApiController
    {
        AirRoutes airRoutes = new AirRoutes();

        [HttpGet]
        public double GetFare (string source, string destination, string Class)
        {
            return Math.Round(airRoutes.CalculateFare(source, destination, Class),2);
        }

        [HttpGet]
        [Route("api/getDestinations")]
        public IEnumerable<string[]> GetDestinations()
        {
            return airRoutes.getDestinations();
        }
    }
}