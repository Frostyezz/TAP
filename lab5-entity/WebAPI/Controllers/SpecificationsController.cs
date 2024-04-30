using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecificationsController : ControllerBase
    {

        private readonly IRepository<Specifications> _specificationsRepository;


        public SpecificationsController(IRepository<Specifications> specificationsRepository)
        {
            _specificationsRepository = specificationsRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Specifications> Get()
        {
            return _specificationsRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(SpecificationsDto specificationsDto)
        {
            _specificationsRepository.Add(new Specifications(specificationsDto.SpecificationsId, specificationsDto.Cpu, specificationsDto.Gpu, specificationsDto.Memory, specificationsDto.LaptopId));
            _specificationsRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, SpecificationsDto SpecificationsDto)
        {
            Specifications? existingSpecifications = _specificationsRepository.GetById(id);

            if (existingSpecifications == null)
            {
                return NotFound("No item with this id.");
            }

            existingSpecifications.Cpu = SpecificationsDto.Cpu;
            existingSpecifications.Gpu = SpecificationsDto.Gpu;
            existingSpecifications.Memory = SpecificationsDto.Memory;
            existingSpecifications.LaptopId = SpecificationsDto.LaptopId;

            _specificationsRepository.Update(existingSpecifications);
            _specificationsRepository.SaveChanges();

            return Ok("Updated successfully.");
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            Specifications? existingSpecifications = _specificationsRepository.GetById(id);

            if (existingSpecifications == null)
            {
                return NotFound("No item with this id.");
            }

            _specificationsRepository.Remove(existingSpecifications);
            _specificationsRepository.SaveChanges();

            return Ok("Removed successfully.");
        }
    }
}
