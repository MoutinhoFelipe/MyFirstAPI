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
        
        public List<Trip> SelectTripFromDB()
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
                    listTripSelected[i].Id = (int)reader[0];
                    listTripSelected[i].LicensePlate = (string)reader[1];
                    listTripSelected[i].TypeTrip = (string)reader[2];
                    listTripSelected[i].NumberTrip = (string)reader[3];
                    listTripSelected[i].NameDriver = (string)reader[4];
                    listTripSelected[i].PhoneNumberDriver = (string)reader[5];
                    i++;
                }
                return listTripSelected;
            }
        }
        
        public void InsertTripIntoDB(Trip tParameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO trip (license_plate, trip_type, trip_number, driver_name, driver_phone_number)" +
                $" VALUES ('{tParameter.LicensePlate}', '{tParameter.TypeTrip}', '{tParameter.NumberTrip}', '{tParameter.NameDriver}', '{tParameter.PhoneNumberDriver}')";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool CheckTripInDB(Trip tParameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT * FROM trip WHERE id = {tParameter.Id}";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                if (command.ExecuteReader().HasRows == true)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        public void UpdateTripInDB(Trip tParameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE trip SET license_plate = '{tParameter.LicensePlate}', trip_type = '{tParameter.TypeTrip}', trip_number = '{tParameter.NumberTrip}', driver_name = '{tParameter.NameDriver}', driver_phone_number = '{tParameter.PhoneNumberDriver}' WHERE id = {tParameter.Id}";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void PatchUpdateTripInDB(Trip tParameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = $"UPDATE trip SET license_plate = '{tParameter.LicensePlate}' WHERE id = {tParameter.Id}";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTripFromDB(Trip tParameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = $"DELETE FROM trip WHERE id = {tParameter.Id}";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
