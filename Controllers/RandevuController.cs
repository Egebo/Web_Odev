using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Odev.Data;
using Web_Odev.Models;

namespace Web_Odev.Controllers
{
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var randevular = _context.Randevular
                .Include(r => r.Calisan)
                .ToList();
            return View(randevular);
        }

        public IActionResult Ekle()
        {
            ViewBag.Calisanlar = _context.Calisanlar.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevular.Add(randevu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Calisanlar = _context.Calisanlar.ToList();
            return View(randevu);
        }

        public IActionResult Sil(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
