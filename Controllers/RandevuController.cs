using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Odev.Data;
using Web_Odev.Models;

namespace Web_Odev.Controllers
{
    [Authorize(Roles = "Customer,Admin")]
    public class RandevuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RandevuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Randevu Oluşturma Sayfası
        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Calisanlar = _context.Calisanlar.Include(c => c.Hizmetler).ToList();
            return View();
        }

        // Randevu Ekleme İşlemi
        [HttpPost]
        public IActionResult Ekle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Randevular.Add(randevu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Calisanlar = _context.Calisanlar.Include(c => c.Hizmetler).ToList();
            return View(randevu);
        }

        // Admin için Onay Bekleyen Randevular
        [Authorize(Roles = "Admin")]
        public IActionResult OnayBekleyen()
        {
            var randevular = _context.Randevular
                .Include(r => r.Calisan)
                .Where(r => !r.Onaylandi)
                .ToList();
            return View(randevular);
        }

        // Randevu Onaylama
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Onayla(int id)
        {
            var randevu = _context.Randevular.Find(id);
            if (randevu != null)
            {
                randevu.Onaylandi = true;
                _context.SaveChanges();
            }
            return RedirectToAction("OnayBekleyen");
        }
    }
}
