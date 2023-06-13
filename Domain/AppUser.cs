using Microsoft.AspNetCore.Identity;

namespace Data;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public List<ActivityUser> Activities { get; set; } = new List<ActivityUser>();

}