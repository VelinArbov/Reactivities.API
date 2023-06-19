using Microsoft.AspNetCore.Identity;

namespace Data;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public List<ActivityUser> Activities { get; set; } = new List<ActivityUser>();
    public List<Photo> Photos { get; set; } = new List<Photo>();
    public List<UserFollowing> Followings { get; set; } = new List<UserFollowing>();
    public List<UserFollowing> Followers { get; set; } = new List<UserFollowing>();
}