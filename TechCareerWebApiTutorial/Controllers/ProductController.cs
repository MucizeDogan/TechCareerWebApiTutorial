using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechCareerWebApiTutorial.Models;

namespace TechCareerWebApiTutorial.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        static List<Product> products;

        public ProductController() {
            if (products==null) {
                products = ProductService.GetProducts();
            }
        }

        [HttpGet]
        public IActionResult getAll() {
            var firstFourProducts = products.Take(4).ToList();
            return Ok(firstFourProducts);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id) { 
            var value = products.FirstOrDefault(x=>x.ID == id);

            if (value==null) {
                return NotFound();
            } else {
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult create(Product product) {
            product.ID = products.Count + 1;
            products.Add(product);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var value = products.FirstOrDefault(x => x.ID == id);

            if (value == null) {
                return NotFound();
            } else {
                products.Remove(value);
                return Ok(value);
            }
        }
    }
}
