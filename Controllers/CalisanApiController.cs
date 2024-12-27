using Microsoft.AspNetCore.Mvc;
using Web_Odev.Data;
using Web_Odev.Models;

namespace Web_Odev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalisanApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CalisanApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CalisanApi
        [HttpGet]
        public IActionResult GetCalisanlar()
        {
            var calisanlar = _context.Calisanlar.ToList();
            return Ok(calisanlar);
        }

        // GET: api/CalisanApi/5
        [HttpGet("{id}")]
        public IActionResult GetCalisan(int id)
        {
            var calisan = _context.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }
            return Ok(calisan);
        }

        // POST: api/CalisanApi
        [HttpPost]
        public IActionResult AddCalisan([FromBody] Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlar.Add(calisan);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetCalisan), new { id = calisan.Id }, calisan);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/CalisanApi/5
        [HttpPut("{id}")]
        public IActionResult UpdateCalisan(int id, [FromBody] Calisan calisan)
        {
            if (id != calisan.Id)
            {
                return BadRequest();
            }

            var existingCalisan = _context.Calisanlar.Find(id);
            if (existingCalisan == null)
            {
                return NotFound();
            }

            existingCalisan.Ad = calisan.Ad;
            existingCalisan.Uzmanlik = calisan.Uzmanlik;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/CalisanApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCalisan(int id)
        {
            var calisan = _context.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            _context.Calisanlar.Remove(calisan);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
