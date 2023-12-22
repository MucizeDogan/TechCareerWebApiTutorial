using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TechCareerWebApiTutorial.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase {

        private readonly string[] countries = {
    "Türkiye", "Almanya", "Fransa", "ABD", "İngiltere", "Yunanistan", "Bulgaristan", "İsveç", "İsviçre", "Çekya", "Katar", "Rusya", "Özbekistan", "Türkmenistan", "Moğolistan", "Meksika", "Kanada", "İzlanda", "Irak", "Suriye"
        };

        [HttpGet]
        public IActionResult GetAllCountries() {
            var result = new {
                Countries = countries,
                kayitSayisi = countries.Length
            };

            return Ok(result);
        }

        [HttpGet("{sayi}")]
        public IActionResult GetCountries(int sayi) {
            var secilen = new string[sayi];
            Array.Copy(countries, secilen, sayi);

            return Ok(secilen);
        }

    }
}
