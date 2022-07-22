using System.ComponentModel.DataAnnotations;

namespace MyFirstAPI.Requests
{
    public class PostTripRequest
    {
        [StringLength(10, ErrorMessage = "O máximo de caracteres é 10")]
        public string LicensePlate { get; set; }
        [StringLength(50)]
        public string TypeTrip { get; set; }
        [StringLength(10)]
        public string NumberTrip { get; set; }
        [StringLength(50)]
        public string NameDriver { get; set; }
        [StringLength(50)]
        public string PhoneNumberDriver { get; set; }
    }
}
