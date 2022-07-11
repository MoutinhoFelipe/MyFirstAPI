using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Repositories;
using MyFirstAPI.Requests;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JourneyController : ControllerBase
    {
  
        [HttpPost]
        public ActionResult<string> Post([FromBody] JourneyRequest request)
        {
            var journey01 = new JourneyRequest()
            {
                licensePlate = request.licensePlate,
                typeJourney = request.typeJourney,
                numberJourney = request.numberJourney,
                nameDriver = request.nameDriver,
                phoneNumberDriver = request.phoneNumberDriver
            };

            JourneyRepository.InsertJourneyIntoDB(journey01, @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = JourneyAPI; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            return "Journey inserted with success!";
        }
    }
}
