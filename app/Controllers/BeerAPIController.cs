using app.Models;
using app.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerAPIController : ControllerBase
    {
        private readonly BeerDbContext _context;

        public BeerAPIController(BeerDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeerBrandViewModel>> Get()
            => await _context.Beers.Include(b => b.Brand)
            .Select(b => new BeerBrandViewModel
            {
                Name = b.Name,
                Brand = b.Brand.Name
            })
            .ToListAsync();
    }
}