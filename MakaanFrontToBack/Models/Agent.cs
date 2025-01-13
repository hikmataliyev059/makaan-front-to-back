﻿using MakaanFrontToBack.Models.Common;

namespace MakaanFrontToBack.Models;

public class Agent : BaseEntity
{
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile File { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }

}
