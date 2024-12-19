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
    }
}
