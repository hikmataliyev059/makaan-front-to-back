using AutoMapper;
using MakaanFrontToBack.DAL.Context;
using MakaanFrontToBack.DTOs.Agents;
using MakaanFrontToBack.Helpers;
using MakaanFrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakaanFrontToBack.Areas.Manage.Controllers;
[Area("Manage")]
public class AgentController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AgentController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        ICollection<Agent> agents = await _context.Agents
             .Include(x => x.Position)
             .ToListAsync();
        return View(agents);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAgentDto agentDto)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (_context.Agents.Any(x => x.Name == agentDto.Name))
        {
            ModelState.AddModelError("Name", "This agent already exists");
            return View();
        }

        if (agentDto.File == null || !agentDto.File.ContentType.Contains("image"))
        {
            ModelState.AddModelError("File", "Please upload a valid image file");
            return View();
        }

        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", "agent");
        agentDto.ImageUrl = await FileHelper.SaveFileAsync(uploadPath, agentDto.File);

        var agent = _mapper.Map<Agent>(agentDto);

        _context.Agents.Add(agent);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

}
