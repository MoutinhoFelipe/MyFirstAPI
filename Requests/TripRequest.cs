namespace MyFirstAPI.Requests
{
    public class TripRequest
    {
        public int id { get; set; }
        public string licensePlate { get; set; }
        public string typeTrip { get; set; }
        public string numberTrip { get; set; }
        public string nameDriver { get; set; }
        public string phoneNumberDriver { get; set; }
    }
}
