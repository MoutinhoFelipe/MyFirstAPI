using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Responses
{
    public class TripResponse
    {
        public int id { get; set; }
        public string licensePlate { get; set; }
        public string typeTrip { get; set; }
        public string numberTrip { get; set; }
        public string nameDriver { get; set; }
        public string phoneNumberDriver { get; set; }
    }
}
