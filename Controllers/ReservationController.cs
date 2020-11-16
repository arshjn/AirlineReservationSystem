using AirlineReservationSystem.Gateways;
using AirlineReservationSystem.Models;
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

        [HttpGet]
        [Route("api/checkReservation")]
        public Reservation CheckReservation(int pnr)
        {
            return reservationGateway.CheckReservation(pnr);
        }
        
        [HttpGet]
        [Route("api/DoesReservationExist")]
        public bool ReservationExists (int pnr)
        {
            return reservationGateway.checkPNR(pnr);
        }
    }
}