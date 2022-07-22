using System;
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
        
        public int InsertTripIntoDB(PostTripRequest tParameter)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                int id_inserido = 0;
                string queryString = "INSERT INTO trip (license_plate, trip_type, trip_number, driver_name, driver_phone_number) " +
                $" VALUES ('{tParameter.LicensePlate}', '{tParameter.TypeTrip}', '{tParameter.NumberTrip}', '{tParameter.NameDriver}', '{tParameter.PhoneNumberDriver}')";
                string queryStringID = "SELECT ID FROM trip WHERE id = SCOPE_IDENTITY() ";
                var commandInsert = new SqlCommand(queryString, connection);
                var commandSelectID = new SqlCommand(queryStringID, connection);
                connection.Open();
                commandInsert.ExecuteNonQuery();
                var reader = commandSelectID.ExecuteReader();
                while (reader.Read())
                {
                   id_inserido = (int)reader[0];
                }
                return id_inserido;
            }
        }

        public bool CheckRequest(Trip tParameter)
        {
            int max_length_licensePlate = 10;
            int max_length_tripType = 50;
            int max_length_tripNumber = 10;
            int max_length_driverName = 50;
            int max_length_driverPhoneNumber = 50;

            if (tParameter.LicensePlate.Length > max_length_licensePlate || tParameter.TypeTrip.Length > max_length_tripType || tParameter.NumberTrip.Length > max_length_tripNumber || tParameter.NameDriver.Length > max_length_driverName || tParameter.PhoneNumberDriver.Length > max_length_driverPhoneNumber)
            {
                return false;
            } else
            {
                return true;
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
