using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Repositories;
using MyFirstAPI.Requests;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
  
        [HttpPost]
        public ActionResult<string> Post([FromBody] TripRequest request)
        {
            var trip01 = new TripRequest()
            {
                licensePlate = request.licensePlate,
                typeTrip = request.typeTrip,
                numberTrip = request.numberTrip,
                nameDriver = request.nameDriver,
                phoneNumberDriver = request.phoneNumberDriver
            };
           
            var tripRepository01 = new TripRepository(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TripAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            tripRepository01.InsertTripIntoDB(trip01);
            return "Trip inserted with success!";
        }
    }
}
