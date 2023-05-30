using Application.DTOs;

namespace Application.Services;

public interface IActivityService
{
    public Task<List<ActivityDto>> GetActivities();
    public Task<ActivityDto>? GetActivity(Guid id);
}