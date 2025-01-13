using MakaanFrontToBack.DAL.Context;
using MakaanFrontToBack.DTOs.Positions;
using MakaanFrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakaanFrontToBack.Areas.Manage.Controllers;

[Area("Manage")]
public class PositionController : Controller
{
    private readonly AppDbContext _context;

    public PositionController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ICollection<Position> positions = await _context.Positions
            .Include(x => x.Agents)
            .ToListAsync();
        return View(positions);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Position position)
    {
        if (_context.Positions.Any(x => x.Name == position.Name))
        {
            ModelState.AddModelError("Name", "This position already exists");
            return View(position);
        }

        _context.Positions.Add(position);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var position = await _context.Positions.FirstOrDefaultAsync(c => c.Id == id);
        if (position == null)
        {
            return NotFound();
        }

        return View(position);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdatePositionDto newPosition)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var oldPositions = await _context.Positions.FirstOrDefaultAsync(c => c.Id == newPosition.Id);

        if (oldPositions == null) return NotFound();

        oldPositions.Name = newPosition.Name;

        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var position = await _context.Positions.FirstOrDefaultAsync(c => c.Id == id);
        if (position == null)
        {
            return NotFound();
        }

        _context.Positions.Remove(position);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}