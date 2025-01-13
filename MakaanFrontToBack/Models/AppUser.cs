using Microsoft.AspNetCore.Identity;

namespace MakaanFrontToBack.Models;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
}
