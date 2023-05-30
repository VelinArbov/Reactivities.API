using Application.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services;

public class ActivityService : IActivityService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ActivityService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ActivityDto>> GetActivities()
    {
        var activities = await _context.Activities.ToListAsync();
        return _mapper.Map<List<ActivityDto>>(activities);

    }

    public async Task<ActivityDto> GetActivity(Guid id)
    {
        var activity = _context.Activities.FirstOrDefault(x => x.Id == id);
        if (activity == null)
        {
            Console.WriteLine("Error");
            return new ActivityDto();
        }

        return _mapper.Map<ActivityDto>(activity);
    }
}

