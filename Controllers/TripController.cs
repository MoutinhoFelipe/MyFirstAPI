using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Repositories;
using MyFirstAPI.Requests;
using MyFirstAPI.Responses;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {

        [HttpGet] 
        public ActionResult<List<Trip>> Get()
        {
            var tripRepository = new TripRepository(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TripAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            var tripResponse01 = new TripResponse();
            var listTrip = tripRepository.SelectTripFromDB(tripResponse01);
            return listTrip;
        }

  
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
           
            var tripRepository = new TripRepository(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = TripAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            tripRepository.InsertTripIntoDB(trip01);
            return "Trip inserted with success!";
        }
    }
}
