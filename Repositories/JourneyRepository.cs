using System.Data.SqlClient;
using MyFirstAPI.Requests;

namespace MyFirstAPI.Repositories
{
    public static class JourneyRepository
    {
        public static void InsertJourneyIntoDB(JourneyRequest j, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string queryString = "INSERT INTO journey (license_plate, journey_type, journey_number, driver_name, driver_phone_number)" +
                $" VALUES ('{j.licensePlate}', '{j.typeJourney}', '{j.numberJourney}', '{j.nameDriver}', '{j.phoneNumberDriver}')";
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
