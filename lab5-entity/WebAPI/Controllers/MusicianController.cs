using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicianController : ControllerBase
    {

        private readonly IRepository<Musician> _musicianRepository;


        public MusicianController(IRepository<Musician> musicianRepository)
        {
            _musicianRepository = musicianRepository;
        }


        [HttpGet("get")]
        public IEnumerable<Musician> Get()
        {
            return _musicianRepository.GetAll();
        }

        [HttpPost("add")]
        public ObjectResult Add(MusicianDto musicianDto)
        {
            _musicianRepository.Add(new Musician(musicianDto.MusicianId, musicianDto.MusicianName));
            _musicianRepository.SaveChanges();

            return Ok("Added successfully.");
        }

        [HttpPut("update")]
        public ObjectResult Update(Guid id, MusicianDto musicianDto)
        {
            Musician? existingMusician = _musicianRepository.GetById(id);

            if (existingMusician == null)
            {
                return NotFound("No item with this id.");
            }

            existingMusician.MusicianName = musicianDto.MusicianName;

            _musicianRepository.Update(existingMusician);
            _musicianRepository.SaveChanges();

            return Ok("Updated successfully.");
        }



        [HttpPut("delete")]
        public ObjectResult Delete(Guid id)
        {
            Musician? existingMusician = _musicianRepository.GetById(id);

            if (existingMusician == null)
            {
                return NotFound("No item with this id.");
            }

            _musicianRepository.Remove(existingMusician);
            _musicianRepository.SaveChanges();

            return Ok("Removed successfully.");
        }
    }
}

