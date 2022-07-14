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

        public TripRepository TripRepository { get; set; }
        public TripController()
        {
            this.TripRepository = new TripRepository(MyConfig.ConnectionString);
        }

        [HttpGet] 
        public ActionResult<List<Trip>> Get()
        {
            var listTrip = TripRepository.SelectTripFromDB();
            return listTrip;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] CreateTripRequest request)
        {
            var trip01 = new Trip()
            {
                LicensePlate = request.LicensePlate,
                TypeTrip = request.TypeTrip,
                NumberTrip = request.NumberTrip,
                NameDriver = request.NameDriver,
                PhoneNumberDriver = request.PhoneNumberDriver
            };
           
            TripRepository.InsertTripIntoDB(trip01);
            return Ok(request);
            //return Ok(request);
            //return Accepted();
        }

        [HttpPatch]
        public ActionResult<string> Patch([FromBody] ModifyTripRequest request)
        {
            var trip01 = new Trip()
            {
                Id = request.Id,
                LicensePlate = request.LicensePlate
            };

            TripRepository.PatchUpdateTripInDB(trip01);
            return "Trip updated with success!";
        }

        [HttpPut]
        public ActionResult<string> Put([FromBody] ModifyTripRequest request)
        {
            var trip01 = new Trip()
            {
                Id = request.Id,
                LicensePlate = request.LicensePlate,
                TypeTrip = request.TypeTrip,
                NumberTrip = request.NumberTrip,
                NameDriver = request.NameDriver,
                PhoneNumberDriver = request.PhoneNumberDriver
            };

            TripRepository.UpdateTripInDB(trip01);
            return "Trip updated with success!";
        }

        [HttpDelete]
        public ActionResult<string> Delete([FromBody] ModifyTripRequest request)
        {
            var trip01 = new Trip()
            {
                Id = request.Id,
            };

            TripRepository.DeleteTripFromDB(trip01);
            return "Trip deleted with success!";
        }
    }
}
