using app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    public class BrandController : Controller
    {
        private readonly BeerDbContext _context;

        public BrandController(BeerDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() => 
            View(await _context.Brands.ToListAsync());
    }
}