using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerOdev5.Odev_5.Models;
using TechCareerOdev5.Odev_5.Models.ORM;

namespace Odev_5.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var values = _context.Room.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var value = _context.Room.FirstOrDefault(x => x.Id == id);
            if (value == null) { 
                return NotFound();
            } else { 
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult Create(Room room) {
            if (room == null) return BadRequest();

            room.AddDate = DateTime.Now;
            _context.Room.Add(room);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, room);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Room room) {
            if (room == null) return BadRequest();

            var value = _context.Room.Find(id);
            if (value == null) {
                return NotFound();
            }

            value.Name = room.Name;
            _context.Update(value);
            _context.SaveChanges();
            return Ok(value);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var room = _context.Room.FirstOrDefault(x => x.Id == id);

            if (room == null) {
                return NotFound();
            } else {
                _context.Room.Remove(room);
                _context.SaveChanges();
                return Ok(room);
            }
        }
    }
}
