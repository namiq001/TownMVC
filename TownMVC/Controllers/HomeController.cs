using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TownMVC.Models;
using TownMVC.TownDataContext;
using TownMVC.ViewModels;

namespace TownMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TownDbContext _context;

        public HomeController(TownDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Crud> cruds = await _context.Cruds.ToListAsync();
            HomeVM homeVM = new HomeVM()
            {
                Cruds = cruds,
            };
            return View(homeVM);
        }
    }
}
