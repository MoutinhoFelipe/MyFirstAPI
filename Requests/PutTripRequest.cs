using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Requests
{
    public class PutTripRequest
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string TypeTrip { get; set; }
        public string NumberTrip { get; set; }
        public string NameDriver { get; set; }
        public string PhoneNumberDriver { get; set; }
    }
}
