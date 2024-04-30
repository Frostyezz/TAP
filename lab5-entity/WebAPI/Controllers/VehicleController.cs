using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {

        private readonly IRepository<Vehicle> _vehicleRepository;


        public VehicleController(IRepository<Vehicle> vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(VehicleDto vehicleDto)
        {
            _vehicleRepository.Add(new Vehicle(vehicleDto.VehicleId, vehicleDto.VehicleType));
            _vehicleRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, VehicleDto vehicleDto)
        {
            Vehicle? existingVehicle = _vehicleRepository.GetById(id);

            if (existingVehicle == null)
            {
                return NotFound("No item with this id.");
            }

            existingVehicle.VehicleType = vehicleDto.VehicleType;

            _vehicleRepository.Update(existingVehicle);
            _vehicleRepository.SaveChanges();

            return Ok("Updated successfully.");
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            Vehicle? existingVehicle = _vehicleRepository.GetById(id);

            if (existingVehicle == null)
            {
                return NotFound("No item with this id.");
            }

            _vehicleRepository.Remove(existingVehicle);
            _vehicleRepository.SaveChanges();

            return Ok("Removed successfully.");
        }
    }
}
