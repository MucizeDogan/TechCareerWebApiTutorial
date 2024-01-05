using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechCareerOdev5.Odev_5.Models;
using TechCareerOdev5.Odev_5.Models.ORM;

namespace Odev_5.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase {
        private readonly AppDbContext _context;

        //Const
        public ClientController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var values = _context.Client.Include(x => x.Company).ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var value = _context.Client.Include(x => x.Company).FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();
            else return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(Client client) {
            if (client == null) return BadRequest("Geçersiz");

            Company company = _context.Company.Find(client.CompanyId);
            if (company == null) return BadRequest();

            client.AddDate = DateTime.Now;
            client.Company = company;
            _context.Client.Add(client);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, client);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Client client) {
            if (client == null) return BadRequest();

            var value = _context.Client.Find(id);
            if (value == null) {
                return NotFound();
            }

            value.FirstName = client.FirstName;
            value.LastName = client.LastName;
            value.BirthDate = client.BirthDate;
            value.Address = client.Address;
            value.Email = client.Email;

            Company company = _context.Company.Find(client.CompanyId);
            if (company == null) return BadRequest();
            value.CompanyId = company.Id;
            value.Company = company;

            _context.Update(value);
            _context.SaveChanges();
            return Ok(value);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var value = _context.Client.FirstOrDefault(x => x.Id == id);

            if (value == null) return NotFound();
            else {
                _context.Client.Remove(value);
                _context.SaveChanges();
                return Ok(value);
            }
        }
    }
}
