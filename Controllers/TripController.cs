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
        public IActionResult Post([FromBody]PostTripRequest request)
        {
            
            //Verificar se o Data Annotation é válido
            if (ModelState.IsValid)
            {

                //Executar a Inserção da Viagem no Banco de Dados e retornar o ID inserido como String
                int Id_Inserido = TripRepository.InsertTripIntoDB(request);

                //Instanciando os valores do Request + ID inserido no Banco, à Trip que será enviada a Fila
                var tripToQueue = new Trip();
                tripToQueue.Id = Id_Inserido;
                tripToQueue.LicensePlate = request.LicensePlate;
                tripToQueue.TypeTrip = request.TypeTrip;
                tripToQueue.NameDriver = request.NameDriver;
                tripToQueue.NumberTrip = request.NumberTrip;
                tripToQueue.PhoneNumberDriver = request.PhoneNumberDriver;

                //Enviar a Viagem para Fila
                QueueService.SendToQueue(tripToQueue);

                //Retorno Padrão REST
                return Accepted($"The trip was created with success! ID: {Id_Inserido}");
            } else
            {
                return BadRequest();
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
