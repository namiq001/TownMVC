using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TownMVC.Models;
using TownMVC.TownDataContext;

namespace TownMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class SettingController : Controller
{
    private readonly TownDbContext _context;

    public SettingController(TownDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Setting> settings = await _context.Settings.ToListAsync();
        return View(settings);
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        var settings = await _context.Settings.ToListAsync();
    }
}
