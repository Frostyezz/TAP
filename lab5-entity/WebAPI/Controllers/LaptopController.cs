using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopController : ControllerBase
    {

        private readonly IRepository<Laptop> _laptopRepository;


        public LaptopController(IRepository<Laptop> laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Laptop> Get()
        {
            return _laptopRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(LaptopDto laptopDto)
        {
            _laptopRepository.Add(new Laptop(laptopDto.SpecificationsId, laptopDto.ModelName, laptopDto.LaptopId));
            _laptopRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, LaptopDto laptopDto)
        {
            Laptop? existingLaptop = _laptopRepository.GetById(id);

            if (existingLaptop == null)
            {
                return NotFound("No item with this id.");
            }

            existingLaptop.ModelName = laptopDto.ModelName;
            existingLaptop.SpecificationsId = laptopDto.SpecificationsId;

            _laptopRepository.Update(existingLaptop);
            _laptopRepository.SaveChanges();

            return Ok("Updated successfully.");
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            Laptop? existingLaptop = _laptopRepository.GetById(id);

            if (existingLaptop == null)
            {
                return NotFound("No item with this id.");
            }

            _laptopRepository.Remove(existingLaptop);
            _laptopRepository.SaveChanges();

            return Ok("Removed successfully.");
        }
    }
}
