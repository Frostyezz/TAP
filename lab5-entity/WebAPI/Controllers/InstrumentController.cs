using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstrumentController : ControllerBase
    {

        private readonly IRepository<Instrument> _instrumentRepository;


        public InstrumentController(IRepository<Instrument> instrumentRepository)
        {
            _instrumentRepository = instrumentRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Instrument> Get()
        {
            return _instrumentRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(InstrumentDto instrumentDto)
        {
            _instrumentRepository.Add(new Instrument(instrumentDto.InstrumentId, instrumentDto.InstrumentName));
            _instrumentRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, InstrumentDto instrumentDto)
        {
            Instrument? existingInstrument = _instrumentRepository.GetById(id);

            if (existingInstrument == null)
            {
                return NotFound("No item with this id.");
            }

            existingInstrument.InstrumentName = instrumentDto.InstrumentName;

            _instrumentRepository.Update(existingInstrument);
            _instrumentRepository.SaveChanges();

            return Ok("Updated successfully.");
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            Instrument? existingInstrument = _instrumentRepository.GetById(id);

            if (existingInstrument == null)
            {
                return NotFound("No item with this id.");
            }

            _instrumentRepository.Remove(existingInstrument);
            _instrumentRepository.SaveChanges();

            return Ok("Removed successfully.");
        }
    }
}

