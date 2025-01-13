using MakaanFrontToBack.Models.Common;

namespace MakaanFrontToBack.Models;

public class Position : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Agent>? Agents { get; set; }

}
