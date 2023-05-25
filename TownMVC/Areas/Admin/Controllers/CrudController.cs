using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TownMVC.Models;
using TownMVC.TownDataContext;
using TownMVC.ViewModels.CrudVM;

namespace TownMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class CrudController : Controller
{
    private readonly TownDbContext _context;

    public CrudController(TownDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        List<Crud> cruds = await _context.Cruds.ToListAsync();
        return View(cruds);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCrudVM createCrud)
    {
        if(!ModelState.IsValid) { return View(createCrud); }
        Crud crud = new Crud()
        {
            Title = createCrud.Title,
            Description = createCrud.Description,
            IconUrl = createCrud.IconUrl,
        };
        _context.Cruds.Add(crud);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int Id)
    {
        Crud? crud = await _context.Cruds.FindAsync(Id);
        if(crud is null)
        {
            return NotFound();
        }
        _context.Cruds.Remove(crud);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {
        Crud? crud = await _context.Cruds.FindAsync(Id);
        if(crud is null)
        {
            return NotFound();
        }
        EditCrudVM editCrud = new EditCrudVM()
        {
            Title = crud.Title,
            Description = crud.Description,
            IconUrl = crud.IconUrl,
        };
        return View(editCrud);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int Id, EditCrudVM editCrud)
    {
        Crud? crud = await _context.Cruds.FindAsync(Id);
        if(crud is null)
        {
            return NotFound();
        }
        if(!ModelState.IsValid)
        {
            return View(editCrud);
        }
        crud.Title = editCrud.Title;
        crud.Description = editCrud.Description;
        crud.IconUrl = editCrud.IconUrl;
        _context.Cruds.Update(crud);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Detail(int Id)
    {
        Crud? crud = await _context.Cruds.FindAsync(Id);
        return View(crud);
    }
}
