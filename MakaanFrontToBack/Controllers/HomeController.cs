using MakaanFrontToBack.DAL.Context;
using MakaanFrontToBack.Models;
using MakaanFrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MakaanFrontToBack.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ICollection<Agent> agents = _context.Agents.ToList();
        ICollection<Position> positions = _context.Positions.ToList();

        HomeVm homeVm = new HomeVm()
        {
            Agents = agents,
            Positions = positions,
        };
        return View(homeVm);
    }
}
