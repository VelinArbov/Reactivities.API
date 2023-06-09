﻿using System.Security.AccessControl;
using Data;

namespace Domain;
public class Activity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string City { get; set; }
    public string Venue { get; set; }
    public bool IsCancelled { get; set; }
    public List<ActivityUser> Attendees { get; set; } = new List<ActivityUser>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
}
