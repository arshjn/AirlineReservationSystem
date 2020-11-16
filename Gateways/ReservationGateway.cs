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

        public Reservation CheckReservation(int pnr)
        {
            DatabaseConnection DBconnect = new DatabaseConnection();
            Reservation reservation1 = new Reservation();
            if (DBconnect.OpenConnection())
            {
                string query = "Select * from reservations where PNR = '" + pnr + "'";
                MySqlCommand cmd = new MySqlCommand(query, DBconnect.connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Reservation reservation = new Reservation
                        {
                            Pnr = pnr,
                            flightID = (int)reader["FlightID"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Class = (string)reader["Class"]
                        };
                        reservation1 = reservation;
                    }
                }
                DBconnect.CloseConnection();
            }
            return reservation1;

        }

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
        public bool checkPNR(int pnr)
        {
            DatabaseConnection DBconnect = new DatabaseConnection();
            if (DBconnect.OpenConnection())
            {
                string query = "Select * from reservations where PNR = '" + pnr + "';";
                MySqlCommand cmd = new MySqlCommand(query, DBconnect.connection);
                var x = cmd.ExecuteScalar();
                if (x == null)
                {
                    return false;
                }
                DBconnect.CloseConnection();
            }
            return true;
        }
    }
}