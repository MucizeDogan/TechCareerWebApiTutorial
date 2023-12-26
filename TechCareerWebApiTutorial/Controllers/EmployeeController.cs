using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerWebApiTutorial.Models.ORM;

namespace TechCareerWebApiTutorial.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        private readonly TechCareerDbContext _context;

        public EmployeeController() {
            _context = new TechCareerDbContext();
        }

        [HttpGet]
        public IActionResult GetList() {
            var value = _context.Employees.ToList();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var value = _context.Employees.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Post(Employee employee) {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]
        public IActionResult Put(Employee employee) {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
            
        }
    }
}
