using MakaanFrontToBack.Models;

namespace MakaanFrontToBack.ViewModels;

public class HomeVm
{
    public ICollection<Agent> Agents { get; set; }
    public ICollection<Position> Positions { get; set; }
}
