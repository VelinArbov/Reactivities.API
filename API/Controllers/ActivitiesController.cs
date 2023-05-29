using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        public ActivitiesController() { }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var activities = new List<Activity>();
            return activities;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetById(Guid Id)
        {
            var activities = new List<Activity>();
            return new Activity();
        }
    }
}
