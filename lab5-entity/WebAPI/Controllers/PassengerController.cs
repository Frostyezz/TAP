using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PassengerController : ControllerBase
    {

        private readonly IRepository<Passenger> _passengerRepository;


        public PassengerController(IRepository<Passenger> passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Passenger> Get()
        {
            return _passengerRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(PassengerDto passengerDto)
        {
            _passengerRepository.Add(new Passenger(passengerDto.PassengerId, passengerDto.PassengerName, passengerDto.VehicleId));
            _passengerRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, PassengerDto passengerDto)
        {
            Passenger? existingPassenger = _passengerRepository.GetById(id);

            if (existingPassenger == null)
            {
                return NotFound("No item with this id.");
            }

            existingPassenger.PassengerName = passengerDto.PassengerName;
            existingPassenger.VehicleId = passengerDto.VehicleId;

            _passengerRepository.Update(existingPassenger);
            _passengerRepository.SaveChanges();

            return Ok("Updated successfully.");
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            Passenger? existingPassenger = _passengerRepository.GetById(id);

            if (existingPassenger == null)
            {
                return NotFound("No item with this id.");
            }

            _passengerRepository.Remove(existingPassenger);
            _passengerRepository.SaveChanges();

            return Ok("Removed successfully.");
        }
    }
}
