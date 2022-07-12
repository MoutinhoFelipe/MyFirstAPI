using System.Data.SqlClient;
using MyFirstAPI.Requests;

namespace MyFirstAPI.Repositories
{
    public class TripRepository
    {
        string connectionString;

        public TripRepository(string conn)
        {
            this.connectionString = conn;
        }

        public void InsertTripIntoDB(TripRequest t)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO trip (license_plate, trip_type, trip_number, driver_name, driver_phone_number)" +
                $" VALUES ('{t.licensePlate}', '{t.typeTrip}', '{t.numberTrip}', '{t.nameDriver}', '{t.phoneNumberDriver}')";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
