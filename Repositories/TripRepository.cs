using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MyFirstAPI.Requests;
using MyFirstAPI.Responses;

namespace MyFirstAPI.Repositories
{
    public class TripRepository
    {
        string connectionString;

        public TripRepository(string conn)
        {
            this.connectionString = conn;
        }

        public void InsertTripIntoDB(TripRequest tRequest)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO trip (license_plate, trip_type, trip_number, driver_name, driver_phone_number)" +
                $" VALUES ('{tRequest.licensePlate}', '{tRequest.typeTrip}', '{tRequest.numberTrip}', '{tRequest.nameDriver}', '{tRequest.phoneNumberDriver}')";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Trip> SelectTripFromDB(TripResponse tResponse)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var listTripSelected = new List<Trip>();
                var tripSelected = new Trip();
                string queryString = "SELECT * FROM trip";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    listTripSelected.Add(new Trip());
                    listTripSelected[i].id = (int)reader[0];
                    listTripSelected[i].licensePlate = (string)reader[1];
                    listTripSelected[i].typeTrip = (string)reader[2];
                    listTripSelected[i].numberTrip = (string)reader[3];
                    listTripSelected[i].nameDriver = (string)reader[4];
                    listTripSelected[i].phoneNumberDriver = (string)reader[5];
                    i++;
                }
                return listTripSelected;
            }
        }
    }
}
