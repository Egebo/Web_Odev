using Microsoft.AspNetCore.Mvc;
using Web_Odev.Data;
using Web_Odev.Models;

namespace Web_Odev.Controllers
{
    public class KuaforController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KuaforController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kuaforler = _context.Kuaforler.ToList();
            return View(kuaforler);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kuafor kuafor)
        {
            if (ModelState.IsValid)
            {
                _context.Kuaforler.Add(kuafor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kuafor);
        }

        public IActionResult Duzenle(int id)
        {
            var kuafor = _context.Kuaforler.Find(id);
            if (kuafor == null)
            {
                return NotFound();
            }
            return View(kuafor);
        }

        [HttpPost]
        public IActionResult Duzenle(Kuafor kuafor)
        {
            if (ModelState.IsValid)
            {
                _context.Kuaforler.Update(kuafor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kuafor);
        }

        public IActionResult Sil(int id)
        {
            var kuafor = _context.Kuaforler.Find(id);
            if (kuafor != null)
            {
                _context.Kuaforler.Remove(kuafor);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
