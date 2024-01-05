using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerOdev5.Odev_5.Models;
using TechCareerOdev5.Odev_5.Models.ORM;

namespace Odev_5.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase {
        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var values = _context.Reservation.Include(x => x.Room).Include(x => x.Client.Company).ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var reservation = _context.Reservation.Include(x => x.Room).Include(x => x.Client.Company).FirstOrDefault(r => r.Id == id);

            if (reservation == null)
                return NotFound();

            return Ok(reservation);
        }


        [HttpPost]
        public IActionResult Create(Reservation reservation) {
            if (reservation == null)
                return BadRequest();

            reservation.AddDate = DateTime.Now;
            Client client = _context.Client.Find(reservation.ClientId);
            Room room = _context.Room.Find(reservation.RoomId);
            if (room == null || client == null) 
                return BadRequest();

            reservation.Client = client;
            reservation.ClientId = client.Id;
            reservation.Room = room;
            reservation.RoomId = room.Id;
            
            _context.Reservation.Add(reservation);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, reservation);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Reservation reservation) {
            var value = _context.Reservation.FirstOrDefault(x => x.Id == id);

            if (value == null)
                return NotFound();

            Client client = _context.Client.Find(reservation.ClientId);
            Room room = _context.Room.Find(reservation.RoomId);
            if (room == null || client == null) return BadRequest();

            value.Client = client;
            value.ClientId = client.Id;
            value.Room = room;
            value.RoomId = room.Id;

            value.EntryReservation = reservation.EntryReservation;
            value.ExitReservation = reservation.ExitReservation;
            value.RoomId = reservation.RoomId;
            value.ClientId = reservation.ClientId;

            _context.Reservation.Update(value);
            _context.SaveChanges();

            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var reservation = _context.Reservation.FirstOrDefault(x => x.Id == id);

            if (reservation == null)
                return NotFound();

            _context.Reservation.Remove(reservation);
            _context.SaveChanges();

            return Ok(reservation);
        }
    }
}
