using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Web_Odev.Data;
using Web_Odev.Models;

[Authorize(Roles = "Customer,Admin")]
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
}
