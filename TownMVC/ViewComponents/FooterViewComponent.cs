using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TownMVC.Models;
using TownMVC.TownDataContext;

namespace TownMVC.ViewComponents;

public class FooterViewComponent : ViewComponent
{
    private readonly TownDbContext _context;

    public FooterViewComponent(TownDbContext context)
    {
        _context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        Dictionary<string, Setting> setting = await _context.Settings.ToDictionaryAsync(s => s.Key);
        return View(setting);
    }
}
