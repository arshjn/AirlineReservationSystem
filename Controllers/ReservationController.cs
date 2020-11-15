using AirlineReservationSystem.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AirlineReservationSystem.Controllers
{
    public class ReservationController : ApiController
    {
        ReservationGateway reservationGateway = new ReservationGateway();

        [HttpGet]
        public int NewReservation(int flightId, string firstName, string lastName, string Class)
        {
            return reservationGateway.newReservation(firstName, lastName, flightId, Class);
        }
    }
}