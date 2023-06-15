﻿using Data;

namespace Application.Profiles;

public class Profile
{
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string Image { get; set; }
    public List<Photo> Photos { get; set; }
}