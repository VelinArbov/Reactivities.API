using Application.DTOs;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly IActivityService _activityService;
        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityDto>>> GetActivities()
        {
            
            return await _activityService.GetActivities(); ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetById(Guid id)
        {
            return await _activityService.GetActivity(id);
        }
    }
}
