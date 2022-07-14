using System.Collections.Generic;
using System.Net;
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
            return Ok(listTrip);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateTripRequest request)
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
            return NoContent();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] PatchTripRequest request)
        {
            var trip01 = new Trip()
            {
                Id = request.Id,
                LicensePlate = request.LicensePlate
            };

            if (TripRepository.CheckTripInDB(trip01) == true)
            {
                TripRepository.PatchUpdateTripInDB(trip01);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] PutTripRequest request)
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

            if (TripRepository.CheckTripInDB(trip01) == true)
            {
                TripRepository.UpdateTripInDB(trip01);
                return NoContent();
            } else
            {
                return NotFound();
            }
            
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] PutTripRequest request)
        {
            var trip01 = new Trip()
            {
                Id = request.Id,
            };

            if (TripRepository.CheckTripInDB(trip01) == true)
            {
                TripRepository.DeleteTripFromDB(trip01);
                return NoContent();
            } else
            {
                return NotFound();
            }
                
        }
    }
}
