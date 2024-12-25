using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Odev.Data;
using Web_Odev.Models;

namespace Web_Odev.Controllers
{
    [Authorize(Roles = "Admin")] // Sadece Admin rolündeki kullanıcılar erişebilir
    public class CalisanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalisanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var calisanlar = _context.Calisanlar.ToList();
            return View(calisanlar);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                _context.Calisanlar.Add(calisan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calisan);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            var calisan = _context.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            _context.Calisanlar.Remove(calisan);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var calisan = _context.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        [HttpPost]
        public IActionResult Duzenle(Calisan calisan)
        {
            if (ModelState.IsValid)
            {
                var mevcutCalisan = _context.Calisanlar.Find(calisan.Id);
                if (mevcutCalisan == null)
                {
                    return NotFound();
                }

                mevcutCalisan.Ad = calisan.Ad;
                mevcutCalisan.Uzmanlik = calisan.Uzmanlik;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calisan);
        }

    }
}
