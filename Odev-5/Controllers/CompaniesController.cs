using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerOdev5.Odev_5.Models;
using TechCareerOdev5.Odev_5.Models.ORM;

namespace Odev_5.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var values = _context.Company.ToList();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var value = _context.Company.FirstOrDefault(x => x.Id == id);
            if (value == null) return NotFound();
            else return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(Company company) {
            if (company == null) 
                return BadRequest();

            company.AddDate = DateTime.Now;
            _context.Company.Add(company);
            _context.SaveChanges();
            //201 Başarılı kayıt
            return StatusCode(StatusCodes.Status201Created, company);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Company company) {
            if (company == null) return BadRequest();

            var value = _context.Company.Find(id);
            if (value == null) 
                return NotFound();

            value.Name = company.Name;
            value.Address = company.Address;
            _context.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var value = _context.Company.FirstOrDefault(x => x.Id == id);

            if (value == null) return NotFound();
            else {
                _context.Company.Remove(value);
                _context.SaveChanges();
                return Ok(value);
            }
        }
    }
}
