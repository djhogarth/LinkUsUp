
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DatabaseContext _databaseContext;
        public ActivitiesController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet]

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _databaseContext.Activities.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await _databaseContext.Activities.FindAsync(id);
        }

    }
}