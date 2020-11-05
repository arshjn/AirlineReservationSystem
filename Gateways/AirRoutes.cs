using AirlineReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Gateways
{
    public class AirRoutes
    {
        private static List<Destination> Destinations = new List<Destination>();
        const double PricePerUnit = 0.3;

        static AirRoutes()
        {
            Destination FortLauderdale = new Destination
            {
                DName = "Fort Lauderdale",
                Code = "FLL",
                Xcoordinate = 0,
                Ycoordinate = 0,
                AirportFee = 100
            };

            Destination NewYork = new Destination
            {
                DName = "New York City",
                Code = "NYC",
                Xcoordinate = 0,
                Ycoordinate = 1000,
                AirportFee = 25
            };
            Destination Dallas = new Destination
            {
                DName = "Dallas",
                Code = "DAL",
                Xcoordinate = -600,
                Ycoordinate = 300,
                AirportFee = 50
            };
            Destination London = new Destination
            {
                DName = "London",
                Code = "LON",
                Xcoordinate = 1500,
                Ycoordinate = 900,
                AirportFee = 200
            };

            Destinations.Add(FortLauderdale);
            Destinations.Add(NewYork);
            Destinations.Add(Dallas);
            Destinations.Add(London);
        }

        public IEnumerable<string[]> getDestinations()
        {
            List<string[]> dests = new List<string[]>();
            foreach (var destination in Destinations)
            {
                string[] temp = new string[2];
                temp[0] = destination.Code;
                temp[1] = destination.DName;
                dests.Add(temp);
            }
            return dests;
        }

        public double CalculateFare(string Scode, string Dcode)
        {
            Destination Source = Destinations.Where(n => n.Code == Scode).FirstOrDefault();
            Destination Dest = Destinations.Where(n => n.Code == Dcode).FirstOrDefault();
            double Distance = 0;
            int Xdist = Math.Abs(Source.Xcoordinate - Dest.Xcoordinate);
            int Ydist = Math.Abs(Source.Ycoordinate - Dest.Ycoordinate);
            Distance = Math.Sqrt(Math.Pow(Xdist, 2) + Math.Pow(Ydist, 2));
            return Distance * PricePerUnit + Source.AirportFee + Dest.AirportFee;
        }
    }
}