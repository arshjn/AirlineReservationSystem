using AirlineReservationSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineReservationSystem.Gateways
{
    public class ReservationGateway
    {

        //Returns PNR after creating new reservation
        public int newReservation(string passengerFname, string passengerLname, int flightID, string Class)
        {
            Random random = new Random();
            int pnr = random.Next(10000);
            while (checkPNR(pnr))
            {
                pnr = random.Next(10000);
            }
            AddReservationToDatabase(passengerFname, passengerLname, flightID, Class, pnr);
            return pnr;
        }

        void AddReservationToDatabase(string passengerFname, string passengerLname, int flightID, string Class, int pnr)
        {
            DatabaseConnection DBconnect = new DatabaseConnection();
            if (DBconnect.OpenConnection())
            {
                string query = "INSERT INTO reservations (PNR, FlightID, FirstName, LastName, Class) VALUES ('" + pnr + "', '" + flightID + "', '" + passengerFname + "', '" + passengerLname + "','" + Class + "')";
                MySqlCommand cmd = new MySqlCommand(query, DBconnect.connection);
                cmd.ExecuteNonQuery();
                DBconnect.CloseConnection();
            }
        }
        bool checkPNR(int pnr)
        {
            DatabaseConnection DBconnect = new DatabaseConnection();
            if (DBconnect.OpenConnection())
            {
                string query = "Select PNR, FlightID from reservations where PNR = '" + pnr + "'";
                MySqlCommand cmd = new MySqlCommand(query, DBconnect.connection);
                int x = cmd.ExecuteNonQuery();
                if (x > 0)
                {
                    return true;
                }
                DBconnect.CloseConnection();
            }
            return false;
        }
    }
}