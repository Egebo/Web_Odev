using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Odev.Data;
using Web_Odev.Models;

namespace Web_Odev.Controllers
{
    public class KuaförController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KuaförController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kuaför
        public async Task<IActionResult> Index()
        {
            return _context.Kuaförler != null ?
                        View(await _context.Kuaförler.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Kuaförler'  is null.");
        }

        // GET: Kuaför/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kuaförler == null)
            {
                return NotFound();
            }

            var kuaför = await _context.Kuaförler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kuaför == null)
            {
                return NotFound();
            }

            return View(kuaför);
        }

        // GET: Kuaför/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kuaför/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Adres,CalismaSaatleri")] Kuaför kuaför)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kuaför);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kuaför);
        }

        // GET: Kuaför/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kuaförler == null)
            {
                return NotFound();
            }

            var kuaför = await _context.Kuaförler.FindAsync(id);
            if (kuaför == null)
            {
                return NotFound();
            }
            return View(kuaför);
        }

        // POST: Kuaför/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Adres,CalismaSaatleri")] Kuaför kuaför)
        {
            if (id != kuaför.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kuaför);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KuaförExists(kuaför.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kuaför);
        }

        // GET: Kuaför/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kuaförler == null)
            {
                return NotFound();
            }

            var kuaför = await _context.Kuaförler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kuaför == null)
            {
                return NotFound();
            }

            return View(kuaför);
        }

        // POST: Kuaför/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kuaförler == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Kuaförler'  is null.");
            }
            var kuaför = await _context.Kuaförler.FindAsync(id);
            if (kuaför != null)
            {
                _context.Kuaförler.Remove(kuaför);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KuaförExists(int id)
        {
            return (_context.Kuaförler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}