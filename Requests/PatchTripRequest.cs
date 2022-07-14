using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Requests
{
    public class PatchTripRequest
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
    }
}
