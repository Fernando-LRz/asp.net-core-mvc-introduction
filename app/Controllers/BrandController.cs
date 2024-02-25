using app.Models;
using app.Models.ViewModels;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandViewModel model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand()
                {
                    Name = model.Name
                };

                _context.Add(brand);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}