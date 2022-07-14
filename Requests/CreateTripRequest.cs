namespace MyFirstAPI.Requests
{
    public class CreateTripRequest
    {
        public string LicensePlate { get; set; }
        public string TypeTrip { get; set; }
        public string NumberTrip { get; set; }
        public string NameDriver { get; set; }
        public string PhoneNumberDriver { get; set; }
    }
}
