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
        public QueueService QueueService { get; set; }
        public TripController()
        {
            this.TripRepository = new TripRepository(MyConfig.ConnectionString);
            this.QueueService = new QueueService();
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

            //Validação dos Dados de Entrada
            if (TripRepository.CheckRequest(trip01) == true)
            {
                var Id_Inserido = TripRepository.InsertTripIntoDB(trip01);
                QueueService.SendToQueue(Id_Inserido, trip01.NameDriver, trip01.PhoneNumberDriver);
                return Ok($"The trip was created with success! ID: {Id_Inserido}");
            } else
            {
                return BadRequest("Limite de caracteres excedido!");
            }
            
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
