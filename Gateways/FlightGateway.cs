using AirlineReservationSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Gateways
{
    public class FlightGateway
    {
        AirRoutes airRoutes = new AirRoutes();
        public List<Flight> GetFlights(string source, string dest)
        {
            List<Flight> flights = new List<Flight>();
            DatabaseConnection DBconnect = new DatabaseConnection();
            if (DBconnect.OpenConnection())
            {
                string query = "SELECT * FROM flights where source like '" + source + "' and destination like '" + dest + "';";
                MySqlCommand cmd = new MySqlCommand(query, DBconnect.connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Flight temp = new Flight();

                        temp.FlightID = (int)reader.GetValue(0);
                        temp.SourceCode = (string)reader["Source"];
                        temp.DestinationCode = (string)reader["Destination"];
                        var a = reader.GetDateTime("Arrival");
                        var d = reader.GetDateTime("Departure");
                        temp.arrival = a;
                        temp.departure = d;
                        flights.Add(temp);
                    }
                }
                DBconnect.CloseConnection();
            }
            return flights;
        }


    }
}